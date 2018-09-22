namespace NewOnlineTheater.Customer.Application.Dto
{
    using AutoMapper;
    using Domain.Entity;
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerInListDto>()
                .ForMember(destination => destination.Name, opts => opts.MapFrom(source => source.Name.Value))
                .ForMember(destination => destination.Email, opts => opts.MapFrom(source => source.Email.Value))
                .ForMember(destination => destination.MoneySpent, opts => opts.MapFrom(source => source.MoneySpent))
                .ForMember(destination => destination.Status, opts => opts.MapFrom(source => source.Status.Type.ToString()))
                .ForMember(destination => destination.StatusExpirationDate, opts => opts.MapFrom(source => source.Status.ExpirationDate))
                ;
        }
    }
}
