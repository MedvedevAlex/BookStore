using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BookStoreClient.Tests
{
    [TestClass]
    public class BookClientTests : HttpBasedTest
    {
        [TestMethod]
        public async Task ShouldGetBooks()
        {
            //Arrange
            var client = new BookClient(HttpClient);

            //Act
            var response = await client.GetAllBooksAsync(); 

            //Assert
            response.Should().BeNull();

        }
    }
}
