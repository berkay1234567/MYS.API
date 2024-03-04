using Dapper.Core.Entities.Models;
using MusteriYonetimSistemi.Data.ViewModels;

namespace Dapper.Application.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<IEnumerable<CustomerOrderViewModel>> GetAllAsync();


        public Task<IEnumerable<Order>> GetByCustomerIdAsync(int Customerid);

        public Task<Customer> FindAsync(int id);

    }
}
