using System.Collections.Generic;

namespace Awesome.Data
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> GetCustomers(string query);
    }
}