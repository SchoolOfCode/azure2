using FluentAssertions;
using LibraryApi.Controllers;
using LibraryApi.Data;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApi.UnitTests
{
    public class WhenDeleteIsCalled
    {
        [Fact]
        public async Task ThenA200OKResultIsReturned()
        {
            var controller = new BooksController(Substitute.For<IBooksRepository>());
            var result = await controller.Delete(2) as OkResult;
            result.StatusCode.Should().Be(200);
        }
    }
}
