using Core.Interfaces.Repo;
using Core.Interfaces.Services;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using PhonebookDB.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class PhonebookRepo : IPhonebookRepo
    {
        private readonly PhonebookDBContext _context;
        private readonly ICurrentUserService _currentUserService;
        public PhonebookRepo(ICurrentUserService currentUserService, PhonebookDBContext context)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<bool> AddEntry(Core.Model.Entry contact)
        {


            var phonebook = await _context.PhoneBooks.FirstOrDefaultAsync(x => x.Id == _currentUserService.PhonebookId);
            if (phonebook == null)
            {
                // Hack to add first record into phonebook
                _context.PhoneBooks.Add(new PhoneBook() { CreatedBy = _currentUserService.UserId, CreatedByDate = DateTime.Now, Entries = 0, Name = "First Phonebook" });
                await _context.SaveChangesAsync(CancellationToken.None);
                phonebook = await _context.PhoneBooks.FirstOrDefaultAsync(x => x.Id == _currentUserService.PhonebookId);
            }
            phonebook.Entries++;

            PhonebookDB.EF.Models.Entry entry = new PhonebookDB.EF.Models.Entry();
            entry.Name = contact.Name;
            entry.PhoneNumber = contact.Number;
            entry.PhoneBookId = phonebook.Id;
            entry.CreatedBy = _currentUserService.UserId;
            entry.CreatedByDate = DateTime.Now;

            await _context.Entries.AddAsync(entry);

            await _context.SaveChangesAsync(CancellationToken.None);

            return true;
        }
        public async Task<List<Core.Model.Entry>> GetEntries()
        {
            List<PhonebookDB.EF.Models.Entry> entries = await _context.Entries
                .Where(y => y.PhoneBookId == _currentUserService.PhonebookId).ToListAsync(CancellationToken.None);

            List<Core.Model.Entry> contacts = new List<Core.Model.Entry>();
            entries.ForEach(x =>
            {
                contacts.Add(Core.Model.Entry.Create(x));
            });
            return contacts;
        }

        public async Task<bool> GetPhonebooks() // would return a list of phonebook models if that would even be possible
        {
            var temp = await _context.PhoneBooks
                .Where(y => y.CreatedBy == _currentUserService.UserId).ToListAsync(CancellationToken.None);

            return true;
        }
    }
}
