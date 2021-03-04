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
    public class WhenGetAllIsCalledExpectingManyBooks
    {
        private readonly BooksController _controller;
        private readonly List<Book> _books;

        public WhenGetAllIsCalledExpectingManyBooks()
        {
            _books = new List<Book>
            {
                new Book
                {
                    Id = 123,
                    Title = "The Hobbit",
                    Author = "Tolkien"
                },
                new Book
                {
                    Id = 234,
                    Title = "The Fellowship Of The Ring",
                    Author = "Tolkien"
                }
            };

            var booksRepository = Substitute.For<IBooksRepository>();
            booksRepository.GetAll().Returns(x => _books);

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
        public async Task ThenTwoBooksAreListed()
        {
            var result = await _controller.GetAll();
            var books = ((OkObjectResult)result.Result).Value as List<Book>;
            books.Should().HaveCount(2);
        }

        [Fact]
        public async Task ThenAllListedBooksAreReturned()
        {
            var result = await _controller.GetAll();
            var books = ((OkObjectResult)result.Result).Value as List<Book>;
            books.Should().BeEquivalentTo(_books);
        }
    }
}