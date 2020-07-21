using AutoMapper;
using CustomerInvoiceManager.API.Models;
using CustomerInvoiceManager.Entities;
using CustomerInvoiceManager.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CustomerInvoiceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : DataResponseControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CustomerController(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        [HttpGet]
        public DataResponse<IEnumerable<CustomerModel>> Get()
        {
            return CreateDataResponse(() =>
            {
                IEnumerable<Customer> customers = _dataContext.Customers.ToList();
                return _mapper.Map<IEnumerable<CustomerModel>>(customers);
            });
        }

        [HttpGet("{id}", Name = "Get")]
        public DataResponse<CustomerModel> Get(long id)
        {
            return CreateDataResponse(() =>
            {
                Customer customer = _dataContext.Customers.FirstOrDefault(c => c.ID == id);
                return _mapper.Map<CustomerModel>(customer);
            });
        }

        [HttpPost]
        public void Post([FromBody] CustomerModel value)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _mapper.Map<Customer>(value);
                _dataContext.Customers.Add(customer);
                _dataContext.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody] CustomerModel value)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _dataContext.Customers.FirstOrDefault(c => c.ID == id);
                if (customer != null)
                {
                    customer.Name = value.Name;
                    _dataContext.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Customer customer = _dataContext.Customers.FirstOrDefault(c => c.ID == id);
            if (customer != null)
            {
                _dataContext.Customers.Remove(customer);
                _dataContext.SaveChanges();
            }
        }
    }
}
