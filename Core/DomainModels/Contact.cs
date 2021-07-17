
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Entry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public static Entry Create(PhonebookDB.EF.Models.Entry entry)
        {
            Entry contact = new Entry();
            contact.Id = entry.Id;
            contact.Name = entry.Name;
            contact.Number = entry.PhoneNumber;
            return contact;
        }
    }
}
