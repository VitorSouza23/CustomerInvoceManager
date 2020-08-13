using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerInvoiceManager.API.Models;
using CustomerInvoiceManager.Entities;
using CustomerInvoiceManager.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoiceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : DataResponseControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public InvoiceController(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        [HttpGet]
        public DataResponse<IEnumerable<InvoiceModel>> Get()
        {
            return CreateDataResponse(() =>
            {
                IEnumerable<Invoice> invoices = _dataContext.Invoices.ToList();
                return _mapper.Map<IEnumerable<InvoiceModel>>(invoices);
            });
        }

        [HttpGet("{id}")]
        public DataResponse<InvoiceModel> Get(long id)
        {
            return CreateDataResponse(() =>
            {
                Invoice invoice = _dataContext.Invoices.FirstOrDefault(i => i.ID == id);
                return _mapper.Map<InvoiceModel>(invoice);
            });
        }

        [HttpPost]
        public void Post([FromBody] InvoiceModel value)
        {
            if (ModelState.IsValid)
            {
                Invoice invoice = _mapper.Map<Invoice>(value);
                _dataContext.Invoices.Add(invoice);
                _dataContext.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody] InvoiceModel value)
        {
            if (ModelState.IsValid)
            {
                Invoice invoice = _dataContext.Invoices.FirstOrDefault(i => i.ID == id);
                if(invoice != null)
                {
                    _mapper.Map(value, invoice);
                    invoice.ID = id;
                    _dataContext.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Invoice invoice = _dataContext.Invoices.FirstOrDefault(i => i.ID == id);
            if(invoice != null)
            {
                _dataContext.Invoices.Remove(invoice);
                _dataContext.SaveChanges();
            }
        }

        [HttpGet("contract/{id}")]
        public DataResponse<IEnumerable<InvoiceModel>> GetAllContractInvoices(long id)
        {
            return CreateDataResponse(() =>
            {
                IEnumerable<Invoice> invoices = _dataContext.Invoices
                    .Where(i => i.Contract.ID == id)
                    .Include(i => i.Contract);

                return _mapper.Map<IEnumerable<InvoiceModel>>(invoices);
            });
        }

        [HttpGet("customer/{id}")]
        public DataResponse<IEnumerable<InvoiceModel>> GetAllCustomerInvoices(long id)
        {
            return CreateDataResponse(() =>
            {
                IEnumerable<Invoice> invoices = _dataContext.Invoices
                    .Where(i => i.Contract.Customer.ID == id)
                    .Include(i => i.Contract);

                return _mapper.Map<IEnumerable<InvoiceModel>>(invoices);
            });
        }
    }
}
