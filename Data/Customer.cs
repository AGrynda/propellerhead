using System;
using System.Collections.Generic;

namespace propellerhead.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTime CreatedDateTime{ get; set; }

        public List<Note> Notes { get; set; }
    }
}
