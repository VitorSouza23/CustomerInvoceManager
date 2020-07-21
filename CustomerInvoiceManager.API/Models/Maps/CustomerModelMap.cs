using AutoMapper;
using CustomerInvoiceManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInvoiceManager.API.Models.Maps
{
    public class CustomerModelMap : Profile
    {
        public CustomerModelMap()
        {
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
        }
    }
}
