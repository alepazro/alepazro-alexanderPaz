using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Properties.Service.Application.Interfaces;
using Properties.Service.Infrastructure.Http.Results.Owners;
using Properties.Service.Application.Dtos;
using Properties.Service.Domain.Entities;

namespace Properties.Service.Application.Services
{

    public partial class PropertyApplicationService : IPropertyApplicationService
    {
        public async Task<GetOwnersResult> GetOwnersAsync(OwnersResourceParameters ownersResourceParameters)
        {
            GetOwnersResult result = new();
            var ownerFromRepo = await _unitOfWork.Owners.GetOwnersAsync(ownersResourceParameters);
            var owners = _mapper.Map<List<OwnerDto>>(ownerFromRepo);

            result.Owners = owners;
            return result;
        }
        public async Task<GetOwnerByOwnerIdResult> GetOwnerByOwnerIdAsync(Guid ownerId)
        {
            GetOwnerByOwnerIdResult result = new();
            var ownerFromRepo = await _unitOfWork.Owners.GetOwnerAsync(ownerId);

            if (ownerFromRepo == null)
            {
                return null;
            }

            var Owner = _mapper.Map<OwnerDto>(ownerFromRepo);
            result.Owner = Owner;
            return result;
        }
        public async Task<CreateOwnerResult> CreateOwnerAsync(OwnerForCreationDto owner)
        {
            CreateOwnerResult result = new();
            var validationResult = _validationService.ValidateOwnerCreation(owner);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var ownerEntity = _mapper.Map<Owner>(owner);
            await _unitOfWork.Owners.AddOwnerAsync(ownerEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an owner failed on save.");
            }

            result.Owner = _mapper.Map<OwnerDto>(ownerEntity);
            result.Success = true;
            return result;
        }

        public async Task<bool?> DeleteOwnerAsync(Guid OwnerId)
        {
            var OwnerFronRepo = await _unitOfWork.Owners.GetOwnerAsync(OwnerId);
            if (OwnerFronRepo == null)
            {
                return null;
            }

            await _unitOfWork.Owners.DeleteOwnerAsync(OwnerFronRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting Owner {OwnerId} failed on save.");
            }

            return true;
        }
        public async Task<UpdateOwnerResult> UpdateOwnerAsync(Guid OwnerId, OwnerForUpdateDto Owner)
        {
            UpdateOwnerResult result = new();
            var validationResult = _validationService.ValidateOwnerUpdate(Owner);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var OwnerFromRepo = await _unitOfWork.Owners.GetOwnerAsync(OwnerId);
            if (OwnerFromRepo == null)
            {
                var OwnerToAdd = _mapper.Map<Owner>(Owner);
                OwnerToAdd.OwnerId = OwnerId;

                await _unitOfWork.Owners.AddOwnerAsync(OwnerToAdd);

                if (!await _unitOfWork.SaveAsync())
                {
                    throw new Exception($"Upserting Owner {OwnerId} failed on save.");
                }

                result.OwnerUpserted = _mapper.Map<OwnerDto>(OwnerToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(Owner, OwnerFromRepo);
            await _unitOfWork.Owners.UpdateOwnerAsync(OwnerFromRepo);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Updating Owner {OwnerId} failed on save.");
            }

            result.Success = true;
            return result;
        }
        public async Task<bool> OwnerExistsAsync(Guid OwnerId)
        {
            return await _unitOfWork.Owners.OwnerExists(OwnerId);
        }
      
      
    }






}
