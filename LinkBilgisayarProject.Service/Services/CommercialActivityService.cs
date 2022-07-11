using AutoMapper;
using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;
using LinkBilgisayarProject.Core.Repositories;
using LinkBilgisayarProject.Core.Services;
using LinkBilgisayarProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBilgisayarProject.Service.Services
{
    public class CommercialActivityService : Service<CommercialActivity>, ICommercialActivityService
    {
        private readonly ICommercialActivityRepository _activityService;
        private readonly IMapper _mapper;
        public CommercialActivityService(IGenericRepository<CommercialActivity> repository, IUnitOfWork unitOfWork, ICommercialActivityRepository commercialActivityService , IMapper mapper ) : base(repository, unitOfWork)
        {
            _activityService = commercialActivityService;
            _mapper = mapper;
        }
        public async Task<List<CommercialActivityWithCustomerDto>> GetCommercialActivitiesWithCustomer()
        {
            var commercialActivities = await _activityService.GetCommercialActivityWithCustomer();

            var commercialActiviesDto = _mapper.Map<List<CommercialActivityWithCustomerDto>>(commercialActivities);

            return commercialActiviesDto;
        }
    }
}
