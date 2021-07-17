using Core.Interfaces.Repo;
using Core.Interfaces.Services;
using Core.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Phonebook.Commands
{
    public class AddEntryCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public class AddEntryCommandHandler : IRequestHandler<AddEntryCommand, int>
        {
            private readonly IPhonebookRepo _phonebookRepo;
            public AddEntryCommandHandler(IPhonebookRepo phonebookRepo)
            {
                _phonebookRepo = phonebookRepo;
            }

            public async Task<int> Handle(AddEntryCommand request, CancellationToken cancellationToken)
            {
                Entry contact = new Entry();
                contact.Name = request.Name;
                contact.Number = request.Number;
                await _phonebookRepo.AddEntry(contact);
                return 1;
            }
        }
    }
}
