using System.Threading.Tasks;
using System.Collections.Generic;
using LibraryApi.Models;

namespace LibraryApi.Data
{
    public interface IBooksRepository
    {
        ValueTask<Book> GetById(int id);
        Task Add(Book entity);
        Task Update(Book entity, int id);
        Task Remove(int id);
        Task<IEnumerable<Book>> GetAll();
    }
}