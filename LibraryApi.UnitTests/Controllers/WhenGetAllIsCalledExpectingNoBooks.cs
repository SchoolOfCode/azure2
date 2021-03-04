using FluentAssertions;
using LibraryApi.Controllers;
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApi.UnitTests
{
    public class WhenGetAllIsCalledExpectingNoBooks
    {
        private readonly BooksController _controller;

        public WhenGetAllIsCalledExpectingNoBooks()
        {
            var booksRepository = Substitute.For<IBooksRepository>();
            booksRepository.GetAll().Returns(x => new List<Book>());

            _controller = new BooksController(booksRepository);
        }

        [Fact]
        public async Task ThenAStatusCodeOf200IsReturned()
        {
            var result = await _controller.GetAll();
            var statusCode =((OkObjectResult)result.Result).StatusCode;
            statusCode.Should().Be(200);
        }

        [Fact]
        public async Task ThenZeroBooksAreListed()
        {
            var result = await _controller.GetAll();
            var books = ((OkObjectResult)result.Result).Value as List<Book>;
            books.Should().HaveCount(0);
        }

        [Fact]
        public async Task ThenAllListedBooksAreReturned()
        {
            var result = await _controller.GetAll();
            var books = ((OkObjectResult)result.Result).Value as List<Book>;
            books.Should().BeEmpty();
        }
    }
}