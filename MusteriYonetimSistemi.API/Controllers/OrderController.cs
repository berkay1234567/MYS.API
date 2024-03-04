using Dapper.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;


namespace MusteriYonetimSistemi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                Log.Information("Get All orders => {ex}", ex);

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerOrders(int id) 
        {
            try
            {
                var customer = await _orderRepository.FindAsync(id);
                if (customer == null)
                {
                    Log.Information("Get Customer order by id => customer not found id:{id}", id);
                    return NotFound();

                }
                var orders = await _orderRepository.GetByCustomerIdAsync(id);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                Log.Information("Get orders by customer ıd => {ex}", ex);

                return StatusCode(500, ex.Message);
            }
        }
    }
}
