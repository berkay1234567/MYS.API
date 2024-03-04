using Dapper.Application.Interfaces;
using Dapper.Core.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
                    Log.Information("Get All Customers => customer not found id:{id}",id);

                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                Log.Information("Get Customer By ID => {ex}", ex);

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
                Log.Information("Create Customer => {ex}", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {

            try
            {
                var cus = await _customerRepository.FindAsync(id);
                if (cus == null ||( id != customer.CustomerID))
                {
                    Log.Information("Create Customers => customer not found id:{id}", id);

                    return NotFound();

                }
                await _customerRepository.UpdateAsync(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Information("Update Customer => {ex}", ex);
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
                {
                    Log.Information("Delete Customers => customer not found id:{id}", id);
                    return NotFound();

                }
                var cust = await _customerRepository.DeleteAsync(id);
                return Ok(cust);
            }
            catch (Exception ex)
            {
                Log.Information("Delete Customer => {ex}", ex);

                return StatusCode(500, ex.Message);
            }
        }

    }
}























