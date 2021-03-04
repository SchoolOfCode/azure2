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
    public class WhenAddBookIsCalled
    {
        private readonly Book _book = new Book
        {
            Id = 234,
            Title = "The Fellowship Of The Ring",
            Author = "Tolkien"
        };

        [Fact]
        public async Task ThenAddedBookIsReturned()
        {
            var controller = new BooksController(Substitute.For<IBooksRepository>());

            var addBook = await controller.AddBook(_book);
            var result = ((OkObjectResult) addBook.Result).Value as Book;
            result.Should().Be(_book);
        }
    }
}
