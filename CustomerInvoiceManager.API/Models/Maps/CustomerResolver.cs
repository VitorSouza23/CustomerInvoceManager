using AutoMapper;
using CustomerInvoiceManager.Entities;
using CustomerInvoiceManager.Repository;
using System.Linq;

namespace CustomerInvoiceManager.API.Models.Maps
{
    public class CustomerResolver : IValueResolver<ContractModel, Contract, Customer>
    {
        private readonly DataContext _dataContext;

        public CustomerResolver(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Customer Resolve(ContractModel source, Contract destination, Customer destMember, ResolutionContext context)
        {
            return _dataContext.Customers.FirstOrDefault(c => c.ID == source.CustomerID);
        }
    }
}
