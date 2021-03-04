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

    /// <summary>
    /// AAA Style Tests
    /// </summary>

    public class WhenGetByIdIsCalled
    {
        private readonly Book _book = new Book
        {
            Id = 234,
            Title = "The Fellowship Of The Ring",
            Author = "Tolkien"
        };

        [Fact]
        public async Task WhenBookIsReturned_ThenAStatusCodeOf200IsReturned()
        {
            var booksRepository = Substitute.For<IBooksRepository>();
            booksRepository.GetById(234).Returns(x => _book);

            var controller = new BooksController(booksRepository);

            var result = await controller.GetById(234);
            var statusCode =((OkObjectResult)result.Result).StatusCode;
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task WhenBookIsReturned_ThenAllDetailsOfTheBookAreReturned()
        {
            var booksRepository = Substitute.For<IBooksRepository>();
            booksRepository.GetById(234).Returns(x => _book);

            var controller = new BooksController(booksRepository);
            var result = await controller.GetById(234);
            var books = ((OkObjectResult)result.Result).Value as Book;
            books.Should().BeEquivalentTo(_book);
        }

        [Fact]
        public async Task WhenNoBookIsReturned_ThenAStatusCodeOf200IsReturned()
        {
            var booksRepository = Substitute.For<IBooksRepository>();
            booksRepository.GetById(234).Returns(x => null);

            var controller = new BooksController(booksRepository);
            var result = await controller.GetById(234);
            var statusCode = ((OkObjectResult)result.Result).StatusCode;
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task WhenNoBookIsExpected_ThenNullIsReturned()
        {
            var booksRepository = Substitute.For<IBooksRepository>();
            booksRepository.GetById(234).Returns(x => null);

            var controller = new BooksController(booksRepository);
            var result = await controller.GetById(234);
            var books = ((OkObjectResult)result.Result).Value as Book;
            books.Should().Be(null);
        }
    }
}