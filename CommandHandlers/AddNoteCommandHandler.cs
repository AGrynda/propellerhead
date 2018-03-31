using propellerhead.Commands;
using propellerhead.Data;
using propellerhead.Interfaces;

namespace propellerhead.CommandHandlers
{
    public class AddNoteCommandHandler : ICommandHandler<AddNoteCommand>
    {
        private readonly INotesRepository _notesRepository;

        public AddNoteCommandHandler(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public void Execute(AddNoteCommand command)
        {
            var note = new Note
            {
                CustomerId = command.CustomerId,
                Content = command.Content
            };

            _notesRepository.AddNote(note);   
        }
    }
}
