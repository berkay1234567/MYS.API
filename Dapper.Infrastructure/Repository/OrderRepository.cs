using Dapper.Application.Interfaces;
using Dapper.Core.Entities.Models;

using MusteriYonetimSistemi.Data.ViewModels;
using Serilog;


namespace Dapper.Infrastructure.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ISqlDataAccess _db;

        public OrderRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CustomerOrderViewModel>> GetAllAsync()
        {
            try
            {
                string query = "sp_get_all_orders";
                return await _db.GetData<CustomerOrderViewModel, dynamic>(query, new { });
            }
            catch (Exception ex)
            {
                Log.Information("sp_get_all_orders => {ex}", ex);

                return null;
            }


        }
        
        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(int Customerid)
        {
            try
            {
                IEnumerable<Order> result = await _db.GetData<Order, dynamic>("sp_get_order", new { CustomerID = Customerid });
                return result;
            }
            catch (Exception ex)
            {
                Log.Information("sp_get_order => {ex}", ex);

                return null;
            }

        }

        public async Task<Customer> FindAsync(int id)
        {
            try
            {
                IEnumerable<Customer> result = await _db.GetData<Customer, dynamic>("sp_get_customer", new { id = id });
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Information("sp_get_customer => {ex}", ex);

                return null;
            }

        }

        public Task<bool> AddAsync(Order obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Order obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetByAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Order> IRepository<Order>.FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
