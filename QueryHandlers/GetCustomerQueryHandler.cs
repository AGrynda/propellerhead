using System.Linq;
using propellerhead.Data;
using propellerhead.Interfaces;
using propellerhead.Queries;

namespace propellerhead.QueryHandlers
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly INotesRepository _notesRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository, INotesRepository notesRepository)
        {
            _customerRepository = customerRepository;
            _notesRepository = notesRepository;
        }

        public Customer Execute(GetCustomerQuery query)
        {
            var customer = _customerRepository.GetCustomer(query.CustomerId);
            customer.Notes = _notesRepository.GetNotesForCustomer(query.CustomerId)?.ToList();
            return customer;
        }
    }
}
