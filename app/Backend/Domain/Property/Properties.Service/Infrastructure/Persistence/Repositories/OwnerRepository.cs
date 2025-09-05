using Microsoft.EntityFrameworkCore;
using Properties.Service.Application.Dtos;
using Properties.Service.Domain.Entities;
using Properties.Service.Domain.Interfaces;
using Properties.Service.Infrastructure.Persistence.Contexts;
using Properties.Service.Infrastructure.Persistence.Helpers;

namespace Properties.Service.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PropertiesContext _context;
        public OwnerRepository(
            PropertiesContext context
        )
        {
            _context = context;
        }

        public async Task AddOwnerAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public async Task DeleteOwnerAsync(Owner owner)
        {
            await Task.FromResult(_context.Owners.Remove(owner));
        }

        public async Task<Owner> GetOwnerAsync(Guid ownerId)
        {
            return await _context.Owners.FirstOrDefaultAsync(a => a.OwnerId == ownerId);

        }

        public async Task<List<Owner>> GetOwnersAsync(OwnersResourceParameters ownersResourceParameters)
        {
            var collectionBeforePaging = _context.Owners.AsQueryable();

            if (!string.IsNullOrEmpty(ownersResourceParameters.FirstName))
            {
                var firstNameForWhereClause = ownersResourceParameters.FirstName.Trim().ToLower();
                collectionBeforePaging = collectionBeforePaging.Where(a => a.FirstName.ToLower() == firstNameForWhereClause);
            }

            if (!string.IsNullOrEmpty(ownersResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = ownersResourceParameters.SearchQuery.Trim().ToLower();

                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.FirstName.ToLower().Contains(searchQueryForWhereClause)
                    || a.LastName.ToLower().Contains(searchQueryForWhereClause));
            }

            return await PagedList<Owner>.CreateAsync(collectionBeforePaging,
               ownersResourceParameters.PageNumber.Value,
               ownersResourceParameters.PageSize.Value);
        }

        public async Task<IEnumerable<Owner>> GetOwnersAsync(List<Guid> ownerIds)
        {
            return await _context.Owners.Where(a => ownerIds.Contains(a.OwnerId))
               .OrderBy(a => a.FirstName)
               .OrderBy(a => a.LastName)
               .ToListAsync();
        }

        public async Task<bool> OwnerExists(Guid ownerId)
        {
            return await _context.Owners.AnyAsync(a => a.OwnerId == ownerId);
        }

        public async Task UpdateOwnerAsync(Owner owner)
        {
            var ownerUpdate = await GetOwnerAsync(owner.OwnerId);
            if (ownerUpdate != null)
            {
                ownerUpdate.FirstName = owner.FirstName;
                ownerUpdate.LastName = owner.LastName;
                ownerUpdate.Address = owner.Address;
                ownerUpdate.DateOfBirth = owner.DateOfBirth;
                ownerUpdate.Photo = owner.Photo;
            }
        }

       
    }
}
