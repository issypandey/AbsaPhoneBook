using Core.Interfaces.Repo;
using Core.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Phonebook.Queries.GetPhonebookContactListQuery
{
    public class GetPhonebookEntryListQuery : IRequest<PhonebookEntryListViewModel>
    {
        public class GetPhonebookEntryListQueryHandler : IRequestHandler<GetPhonebookEntryListQuery, PhonebookEntryListViewModel>
        {
            private readonly IPhonebookRepo _phonebookRepo;
            public GetPhonebookEntryListQueryHandler(IPhonebookRepo phonebookRepo)
            {
                _phonebookRepo = phonebookRepo;
            }

            public async Task<PhonebookEntryListViewModel> Handle(GetPhonebookEntryListQuery request, CancellationToken cancellationToken)
            {
                var vm = new PhonebookEntryListViewModel
                {
                    Entries = await _phonebookRepo.GetEntries()
                };

                return vm;
            }
        }
    }
}
