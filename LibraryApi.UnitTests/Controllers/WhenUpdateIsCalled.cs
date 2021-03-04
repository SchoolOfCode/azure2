using FluentAssertions;
using LibraryApi.Controllers;
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApi.UnitTests
{
    public class WhenUpdateIsCalled
    {
        private readonly Book _book = new Book
        {
            Id = 234,
            Title = "The Fellowship Of The Ring",
            Author = "Tolkien"
        };

        [Fact]
        public async Task ThenUpdatedBookIsReturned()
        {
            var controller = new BooksController(Substitute.For<IBooksRepository>());

            var result = await controller.Update(_book, 234);
            var books = ((OkObjectResult)result.Result).Value as Book;
            books.Should().Be(_book);
        }
    }
}
