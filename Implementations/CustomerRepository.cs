using System;
using System.Collections.Generic;
using System.Linq;
using propellerhead.Data;
using propellerhead.Interfaces;

namespace propellerhead.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            if (!_dataContext.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer
                    {
                        CreatedDateTime = new DateTime(2018, 3, 23),
                        Email = "cust11@gmail.com",
                        Name = "Jack Daniels",
                        Status = CustomerStatus.Prospective
                    },
                    new Customer
                    {
                        CreatedDateTime = new DateTime(2018, 3, 25),
                        Email = "cust22@gmail.com",
                        Name = "Andre",
                        Status = CustomerStatus.ProspectiveCurrent
                    },
                    new Customer
                    {
                        CreatedDateTime = new DateTime(2018, 3, 27),
                        Email = "jo22@gmail.com",
                        Name = "John",
                        Status = CustomerStatus.NonActive
                    }
                };

                _dataContext.Customers.AddRange(customers);
                _dataContext.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dataContext.Customers;
        }

        public Customer GetCustomer(int id)
        {
            return _dataContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _dataContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _dataContext.Customers.Remove(customer);
                _dataContext.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            _dataContext.Customers.Update(customer);
            _dataContext.SaveChanges();
        }
    }
}
