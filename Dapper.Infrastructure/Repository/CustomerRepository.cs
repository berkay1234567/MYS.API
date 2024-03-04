using Dapper.Application.Interfaces;
using Dapper.Core.Entities.Models;




namespace Dapper.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISqlDataAccess _db;

        public CustomerRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Customer customer)
        {
            try
            {
                await _db.SaveData("sp_create_customer", new
                {
                    CustomerName = customer.CustomerName,
                    CustomerSurName = customer.CustomerSurName,
                    Address = customer.Address,
                    City = customer.City,
                    Region = customer.Region,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    Email = customer.Email
                });
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            try
            {
                await _db.SaveData("sp_update_customer", customer);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public  async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_delete_customer", new { id = id });
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public  async Task<Customer> GetByIdAsync(int id)
        {

            IEnumerable<Customer> result = await _db.GetData<Customer, dynamic>("sp_get_customer", new { id = id });
            return result.FirstOrDefault();

        }

        public async Task<IEnumerable<Customer>> GetByAllAsync()
        {

            string query = "sp_get_all_customers";
            return await _db.GetData<Customer, dynamic>(query, new { });

        }

        public  async Task<Customer> FindAsync(int id)
        {

            IEnumerable<Customer> result = await _db.GetData<Customer, dynamic>("sp_get_customer", new { id = id });
            return result.FirstOrDefault();

        }


    }


}
