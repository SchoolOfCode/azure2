using Dapper;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using LibraryApi.Queries;
using LibraryApi.Models;

namespace LibraryApi.Data
{
    public class BooksRepository : BaseRepository, IBooksRepository
    {
        private readonly ICommandText _commandText;

        public BooksRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Book>(_commandText.GetBooks);
                return query;
            });
        }

        public async ValueTask<Book> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Book>(_commandText.GetBookById, new { Id = id });
                return query;
            });
        }

        public async Task Add(Book entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.AddBook,
                    new { Title = entity.Title, Author = entity.Author });
            });
        }

        public async Task Update(Book entity, int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.UpdateBook,
                    new { Title = entity.Title, Author = entity.Author, Id = id });
            });
        }

        public async Task Remove(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.RemoveBook, new { Id = id });
            });
        }
    }
}
