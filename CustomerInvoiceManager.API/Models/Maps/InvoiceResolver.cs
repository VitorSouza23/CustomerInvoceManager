using AutoMapper;
using CustomerInvoiceManager.Entities;
using CustomerInvoiceManager.Repository;
using System.Linq;

namespace CustomerInvoiceManager.API.Models.Maps
{
    public class InvoiceResolver : IValueResolver<InvoiceModel, Invoice, Contract>
    {
        private readonly DataContext _dataContext;

        public InvoiceResolver(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Contract Resolve(InvoiceModel source, Invoice destination, Contract destMember, ResolutionContext context)
        {
            return _dataContext.Contracts.FirstOrDefault(c => c.ID == source.ContractID);
        }
    }
}
