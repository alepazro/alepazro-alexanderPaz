using AutoMapper;
using Properties.Service.Application.Interfaces;
using Properties.Service.Infrastructure.Persistence.UnitOfWork;

namespace Properties.Service.Application.Services
{  
    public partial class PropertyApplicationService : IPropertyApplicationService
    {
        private readonly PropertyUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;

        public PropertyApplicationService(
            PropertyUnitOfWork unitOfWork,
            IMapper mapper,
             IValidationService validationService
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
        }
    }

}
