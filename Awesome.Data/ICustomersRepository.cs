using System.Collections.Generic;

namespace Legacy.Data
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetCustomers(string query);
    }
}