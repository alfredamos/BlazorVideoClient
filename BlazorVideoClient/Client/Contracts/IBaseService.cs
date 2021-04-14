using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVideoClient.Client.Contracts
{
    public interface IBaseService<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> AddEntity(T newService);
        Task DeleteEntity(int id);
        Task<T> UpdateEntity(T updatedService);
        Task<IEnumerable<T>> Search(string searchKey);
    }
}
