using AutoMapper;
using CustomerInvoiceManager.Entities;

namespace CustomerInvoiceManager.API.Models.Maps
{
    public class InvoiceModelMap : Profile
    {
        public InvoiceModelMap()
        {
            CreateMap<Invoice, InvoiceModel>()
                .ForMember(dest => dest.ContractID, opt => opt.MapFrom(source => source.Contract.ID))
                .ReverseMap()
                .ForMember(dest => dest.Contract, opt => opt.MapFrom<InvoiceResolver>());
        }
    }
}
