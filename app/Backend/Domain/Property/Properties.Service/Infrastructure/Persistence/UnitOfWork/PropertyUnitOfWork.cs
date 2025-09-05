using Properties.Service.Domain.Interfaces;
using Properties.Service.Infrastructure.Persistence.Contexts;
using static System.Reflection.Metadata.BlobBuilder;

namespace Properties.Service.Infrastructure.Persistence.UnitOfWork
{  
    public class PropertyUnitOfWork : UnitOfWork
    {
        public IOwnerRepository Owners { get; }
        public IPropertyRepository Properties { get; }
        public IImagerRepository Images { get; }
        public PropertiesContext _context { get; }

        public PropertyUnitOfWork(
            PropertiesContext context,
            IOwnerRepository ownerRepository,
            IPropertyRepository propertyRepository,
            IImagerRepository imagerRepository
        ) : base(context)
        {
            _context = context;
            Owners = ownerRepository;
            Properties = propertyRepository;
            Images = imagerRepository;
        }
    }

}
