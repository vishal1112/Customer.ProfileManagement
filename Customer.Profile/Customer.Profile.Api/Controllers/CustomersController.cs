using AutoMapper;
using Customer.Profile.Api.Model;
using Customer.Profile.Store.Model;
using Customer.Profile.Store.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Profile.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerProfileRepository _repository;
        private readonly IMapper _mapper;
        public CustomersController(IMapper mapper, ICustomerProfileRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> Add(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                bool exist = await this._repository.CheckCustomerExist(customer.Email);
                if (exist)
                {
                    return BadRequest("Customer profile with given email already exist!");
                }
                var customerModel = _mapper.Map<CustomerProfile>(customer);
                var result = await this._repository.AddCustomerProfile(customerModel);
                return Ok(_mapper.Map<CustomerViewModel>(result));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerViewModel>>> GetList()
        {
            var custProfileList = await _repository.GeCustomerProfileList();
            if (custProfileList != null)
            {
                var resultList = _mapper.Map<List<CustomerViewModel>>(custProfileList);
                return Ok(resultList);
            }
            return Ok("No record exist!");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerViewModel>> Get(int id)
        {
            var custProfile = await this._repository.GeCustomerProfile(id);
            if (custProfile == null)
            {
                return NotFound();
            }
            return Ok(custProfile);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerViewModel>> Update(int id, CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var customerModel = _mapper.Map<CustomerProfile>(customer);
                var (custProfile, errorMsg) = await _repository.UpdateCustomerProfile(id, customerModel);
                if (custProfile != null)
                {
                    var customerProfileVM = _mapper.Map<CustomerViewModel>(custProfile);
                    return Ok(customerProfileVM);
                }
                return BadRequest(errorMsg);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var success = await _repository.DeleteCustomerProfile(id);
            return Ok(success);
        }


    }
}