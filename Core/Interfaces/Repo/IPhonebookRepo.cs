using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repo
{
    public interface IPhonebookRepo
    {
        Task<bool> AddEntry(Entry contact);
        Task<List<Entry>> GetEntries();
    }
}
