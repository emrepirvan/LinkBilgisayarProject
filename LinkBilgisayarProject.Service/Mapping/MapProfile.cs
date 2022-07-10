using AutoMapper;
using LinkBilgisayarProject.Core.Dtos;
using LinkBilgisayarProject.Core.Entites;

namespace LinkBilgisayarProject.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<WeeklyReport, WeeklyReportDto>().ReverseMap();
            CreateMap<CommercialActivity, CommercialActivityDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
