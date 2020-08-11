using AutoMapper;
using CustomerInvoiceManager.Entities;

namespace CustomerInvoiceManager.API.Models.Maps
{
    public class ContractModelMap : Profile
    {

        public ContractModelMap()
        {
            CreateMap<Contract, ContractModel>()
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(source => source.Customer.ID))
                .ReverseMap()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom<CustomerResolver>());
        }
    }
}
