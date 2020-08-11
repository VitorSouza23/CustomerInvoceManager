using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerInvoiceManager.API.Models;
using CustomerInvoiceManager.Entities;
using CustomerInvoiceManager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInvoiceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : DataResponseControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public ContractController(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        [HttpGet]
        public DataResponse<IEnumerable<ContractModel>> Get()
        {
            return CreateDataResponse(() =>
            {
                IEnumerable<Contract> contracts = _dataContext.Contracts.ToList();
                return _mapper.Map<IEnumerable<ContractModel>>(contracts);
            });
        }

        [HttpGet("{id}")]
        public DataResponse<ContractModel> Get(long id)
        {
            return CreateDataResponse(() =>
            {
                Contract contract = _dataContext.Contracts.FirstOrDefault(c => c.ID == id);
                return _mapper.Map<Contract, ContractModel>(contract);
            });
        }

        [HttpPost]
        public void Post([FromBody] ContractModel contractModel)
        {
            if (ModelState.IsValid)
            {
                Contract contract = _mapper.Map<ContractModel, Contract>(contractModel);
                _dataContext.Contracts.Add(contract);
                _dataContext.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ContractModel contractModel)
        {
            if (ModelState.IsValid)
            {
                Contract contract = _dataContext.Contracts.FirstOrDefault(c => c.ID == id);
                if (contract != null)
                {
                    contract.Name = contractModel.Name;
                    contract.BilingStyartDay = contractModel.BilingStyartDay;
                    contract.DeductibleAmount = contractModel.DeductibleAmount;
                    contract.EndMotnh = contractModel.EndMotnh;
                    contract.EndYear = contractModel.EndYear;
                    contract.LateInterest = contractModel.LateInterest;
                    contract.StartMonth = contractModel.StartMonth;
                    contract.StartYear = contractModel.StartYear;
                    _dataContext.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Contract contract = _dataContext.Contracts.FirstOrDefault(c => c.ID == id);
            if (contract != null)
            {
                _dataContext.Contracts.Remove(contract);
                _dataContext.SaveChanges();
            }
        }

        [HttpGet("customer/{id}")]
        public DataResponse<IEnumerable<ContractModel>> GetAllCustomerContracts(long id)
        {
            return CreateDataResponse(() =>
            {
                IEnumerable<Contract> contracts = _dataContext.Contracts.Where(c => c.Customer.ID == id).ToList();
                return _mapper.Map<IEnumerable<ContractModel>>(contracts);
            });
        }
    }
}
