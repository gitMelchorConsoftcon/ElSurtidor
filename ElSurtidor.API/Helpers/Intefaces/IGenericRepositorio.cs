using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElSurtidor.API.Helpers.Intefaces
{
    public interface IGenericRepositorio<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Post(T obj);
        Task<T> Put(int id,T obj);
        Task<T> Delete(int id);
    }
}
