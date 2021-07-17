using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = "User007";
            PhonebookId = 1;
            //Would normal read from auth token or cookie like below
            //UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("UserId");
        }
        public string UserId { get; set; }
        public int PhonebookId { get; set; }
    }
}
