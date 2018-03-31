using propellerhead.Commands;
using propellerhead.Data;
using propellerhead.Interfaces;

namespace propellerhead.CommandHandlers
{
    public class UpdateCustomerStatusCommandHandler : ICommandHandler<UpdateCustomerStatusCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerStatusCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Execute(UpdateCustomerStatusCommand command)
        {
            var customer = _customerRepository.GetCustomer(command.CustomerId);
            customer.Status = command.NewStatus;
            _customerRepository.UpdateCustomer(customer);
        }
    }
}
