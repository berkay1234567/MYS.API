namespace Dapper.Core.Entities.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
    }
}
