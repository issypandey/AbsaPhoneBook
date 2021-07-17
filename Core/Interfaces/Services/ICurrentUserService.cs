using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        public int PhonebookId { get; }
    }
}
