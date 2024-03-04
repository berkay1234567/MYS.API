using MusteriYonetimSistemi.Data.Models.Domain;
using MusteriYonetimSistemi.Data.ViewModels;


namespace MusteriYonetimSistemi.Data.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<IEnumerable<CustomerOrderViewModel>> GetAllAsync();


        public Task<IEnumerable<Order>> GetByCustomerIdAsync(int Customerid);

    }
}
