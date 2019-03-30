using BAMTriviaProject2MVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BAMTriviaProject2MVC.Testing
{
    public class HomeControllerTest
    {
        [Fact]
        public void TestLoginValidCredentials()
        {
            //var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            //handlerMock
            //   .Protected()
            //   // Setup the PROTECTED method to mock
            //   .Setup<Task<HttpResponseMessage>>(
            //      "SendAsync",
            //      ItExpr.IsAny<HttpRequestMessage>(),
            //      ItExpr.IsAny<CancellationToken>()
            //   )
            //   // prepare the expected response of the mocked http call
            //   .ReturnsAsync(new HttpResponseMessage()
            //   {
            //       StatusCode = HttpStatusCode.OK,
            //       Content = new StringContent("[{'id':1,'value':'1'}]"),
            //   })
            //   .Verifiable();

            //var httpClient = new HttpClient(handlerMock.Object)
            //{
            //    BaseAddress = new Uri("http://bam1902trivia.azurewebsites.net/"),
            //};
            ////IConfiguration configuration = Mock.Of<IConfiguration>();
            //ILogger<HomeController> logger = Mock.Of<ILogger<HomeController>>();
            //Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            //configuration.Setup(c => c.GetSection(It.IsAny<String>())).Returns(new Mock<IConfigurationSection>().Object);

            //var sut = new HomeController(httpClient, null, logger);


   //         var result = await sut
   //.GetSomethingRemoteAsync('api/test/whatever');

            // ASSERT
            //result.Should().NotBeNull(); // this is fluent assertions here...
            //result.Id.Should().Be(1);

            // also check the 'http' call was like we expected it
            //var expectedUri = new Uri("http://test.com/api/test/whatever");

            //handlerMock.Protected().Verify(
            //   "SendAsync",
            //   Times.Exactly(1), // we expected a single external request
            //   ItExpr.Is<HttpRequestMessage>(req =>
            //      req.Method == HttpMethod.Get  // we expected a GET request
            //      && req.RequestUri == expectedUri // to this uri
            //   ),
            //   ItExpr.IsAny<CancellationToken>()
            //);

        }
       
    }
}
