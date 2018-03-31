using propellerhead.Data;

namespace propellerhead.Commands
{
    public class UpdateCustomerStatusCommand : ICommand
    {
        public int CustomerId { get; set; }
        public CustomerStatus NewStatus { get; set; }
    }
}
