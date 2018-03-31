using Microsoft.AspNetCore.Mvc;
using propellerhead.Commands;
using propellerhead.Interfaces;

namespace propellerhead.Controllers
{
    [Route("api/[controller]")]
    public class NotesController: Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public NotesController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpDelete("{id}")]
        public void DeleteNote(int id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id
            };
            _commandDispatcher.Dispatch(command);
        }


        [HttpPost]
        public void CreateNote([FromBody] AddNoteCommand command)
        {
            _commandDispatcher.Dispatch(command);
        }

    }
}
