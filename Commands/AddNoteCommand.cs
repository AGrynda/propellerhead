namespace propellerhead.Commands
{
    public class AddNoteCommand : ICommand
    {
        public int CustomerId { get; set; }
        public string Content { get; set; }
    }
}
