using System.Collections.Generic;
using propellerhead.Data;

namespace propellerhead.Interfaces
{
    public interface INotesRepository
    {
        IEnumerable<Note> GetNotes();
        IEnumerable<Note> GetNotesForCustomer(int customerId);
        void UpdateNote(Note note);
        void AddNote(Note note);
        void DeleteNote(int id);
    }
}
