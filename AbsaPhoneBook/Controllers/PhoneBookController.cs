using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsaPhoneBook.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Phonebook.Commands;
using Services.Phonebook.Queries.GetPhonebookContactListQuery;

namespace AbsaPhoneBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetPhonebookEntryListQuery()));
        }

        [HttpGet("{id}")]
        [AuthorizeCheck(true,false)]
        public async Task<ActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post(AddEntryCommand entryCommand)
        {
            return Ok(await Mediator.Send(entryCommand));
        }

        [HttpPut]
        [AuthorizeCheck(false, true)]
        public async Task<ActionResult> Put(UpdateEntryCommand entryCommand)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [AuthorizeCheck(true, false)]
        public async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
