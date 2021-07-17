using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Phonebook.Commands
{
    public class UpdateEntryCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand, int>
        {

            public UpdateEntryCommandHandler()
            {
            }

            public async Task<int> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
            {
                    throw new NotImplementedException();
            }
        }
    }
}
