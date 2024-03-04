using MusteriYonetimSistemi.Data.Interfaces;
using MusteriYonetimSistemi.Data.Models.Domain;
using MusteriYonetimSistemi.Data.ViewModels;


namespace MusteriYonetimSistemi.Data.Repository
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

            string query = "sp_get_all_orders";
            return await _db.GetData<CustomerOrderViewModel, dynamic>(query, new { });

        }
        
        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(int Customerid)
        {

            IEnumerable<Order> result = await _db.GetData<Order, dynamic>("sp_get_order", new { CustomerID = Customerid });
            return result;

        }

        public async Task<Customer> FindAsync(int id)
        {

            IEnumerable<Customer> result = await _db.GetData<Customer, dynamic>("sp_get_customer", new { id = id });
            return result.FirstOrDefault();
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
