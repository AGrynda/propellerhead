using System.Collections.Generic;
using System.Linq;
using propellerhead.Data;
using propellerhead.Interfaces;
using propellerhead.Queries;

namespace propellerhead.QueryHandlers
{
    public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> Execute(GetCustomersQuery query)
        {
            var customers = _customerRepository.GetCustomers();
            if (!string.IsNullOrEmpty(query.Search))
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(query.Search)
                                        || c.Email.ToLower().Contains(query.Search));
            }

            switch (query.OrderBy)
            {
                case "name":
                    customers = customers.OrderBy(c => c.Name);
                    break;
                case "email":
                    customers = customers.OrderBy(c => c.Email);
                    break;
                default:
                    break;
            }

            return customers;
        }
    }
}
