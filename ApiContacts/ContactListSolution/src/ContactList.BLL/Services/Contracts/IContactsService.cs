using ContactList.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.BLL.Services.Contracts
{
    public interface IContactsService
    {
        Task<List<ContactDTOs>> ListFilterByAdressAndName(string search);
        Task<List<ContactDTOs>> FindRangeAge(int ageinit, int agefinal);
        Task<ContactDTOs> FindById(int id);
        Task<ContactDTOs> Create(ContactDTOs modelo);
        Task<bool> Update(ContactDTOs modelo);
        Task<bool> Delete(int id);
    }
}
