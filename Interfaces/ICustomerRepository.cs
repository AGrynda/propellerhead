using System.Collections.Generic;
using propellerhead.Data;

namespace propellerhead.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);
    }
}
