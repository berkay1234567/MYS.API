using Dapper.Application.Interfaces;
using Dapper.Core.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusteriYonetimSistemi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _customerRepository.GetByAllAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            try
            {
                var _cust = await _customerRepository.AddAsync(customer);
                return Ok(_cust);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {

            try
            {
                var cus = await _customerRepository.FindAsync(id);
                if (cus == null)
                    return NotFound();
                await _customerRepository.UpdateAsync(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _customerRepository.FindAsync(id);
                if (customer == null)
                    return NotFound();
                var cust = await _customerRepository.DeleteAsync(id);
                return Ok(cust);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

    }
}























