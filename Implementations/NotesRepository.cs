using System;
using System.Collections.Generic;
using System.Linq;
using propellerhead.Data;
using propellerhead.Interfaces;

namespace propellerhead.Implementations
{
    public class NotesRepository : INotesRepository
    {
        private readonly DataContext _dataContext;

        public NotesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            if (!_dataContext.Notes.Any())
            {

                var notes = new List<Note>
                {
                    new Note
                    {
                        CustomerId = 1,
                        Content = "Note first"
                    },
                    new Note
                    {
                        CustomerId = 1,
                        Content = "important note first"
                    },
                    new Note
                    {
                        CustomerId = 2,
                        Content = "important note first"
                    }
                };

                _dataContext.Notes.AddRange(notes);
                _dataContext.SaveChanges();
            }
        }

        public IEnumerable<Note> GetNotes()
        {
            return _dataContext.Notes;
        }

        public IEnumerable<Note> GetNotesForCustomer(int customerId)
        {
            return _dataContext.Notes.Where(n => n.CustomerId == customerId);
        }

        public void UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }

        public void AddNote(Note note)
        {
            _dataContext.Notes.Add(note);
            _dataContext.SaveChanges();
        }

        public void DeleteNote(int id)
        {
            var note = _dataContext.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                _dataContext.Notes.Remove(note);
                _dataContext.SaveChanges();
            }
        }
    }
}