using AutoMapper;
using CustomerInvoiceManager.Entities;
using CustomerInvoiceManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInvoiceManager.API.Models.Maps
{
    public class ContractModelMap : Profile
    {
        private readonly DataContext _dataContext;

        public ContractModelMap(DataContext dataContext)
        {
            _dataContext = dataContext;

            CreateMap<Contract, ContractModel>()
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(source => source.Customer.ID))
                .ReverseMap()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(source => _dataContext.Customers.FirstOrDefault(c => c.ID == source.CustomerID)));
        }
    }
}
