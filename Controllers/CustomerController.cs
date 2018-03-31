using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using propellerhead.Commands;
using propellerhead.Data;
using propellerhead.Interfaces;
using propellerhead.Queries;

namespace propellerhead.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public CustomersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers([FromQuery] string search, [FromQuery] string orderBy)
        {
            var query = new GetCustomersQuery
            {
                Search = search,
                OrderBy = orderBy
            };
            return _queryDispatcher.Execute<GetCustomersQuery, IEnumerable<Customer>>(query);
        }

        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            var query = new GetCustomerQuery
            {
                CustomerId = id
            };
            return _queryDispatcher.Execute<GetCustomerQuery, Customer>(query);
        }


        [HttpPut("{id}/status")]
        public void UpdateStatus(int id, [FromBody] UpdateStatusInfo info)
        {
            var command = new UpdateCustomerStatusCommand
            {
                CustomerId = id,
                NewStatus = (CustomerStatus) info.NewStatus
            };
            _commandDispatcher.Dispatch(command);
        }


    }
}
