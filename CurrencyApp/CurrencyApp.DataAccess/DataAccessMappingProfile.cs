using AutoMapper;

namespace CurrencyApp.DataAccess
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Entities.Currency, Domain.Currency>().ReverseMap();
        }
    }
}
