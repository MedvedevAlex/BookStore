using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BooksStore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreClient.Tests
{
    public class HttpBasedTest
    {
        private HttpClient _httpClient;
        private TestServer _host;

        public HttpClient HttpClient { get => _httpClient; set => _httpClient = value; }

        [TestInitialize]
        public async Task StartServer()
        {
            var args = new List<string> { };
            _host = new TestServer(
                WebHost
                    .CreateDefaultBuilder(args.ToArray())
                    .ConfigureAppConfiguration((hostingContext, cfg) =>
                    {
                        cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                        if (args != null)
                        {
                            cfg.AddCommandLine(args.ToArray());
                        }
                    })
                    .UseStartup<Startup>());

            _httpClient = _host.CreateClient();
            await Task.CompletedTask;
        }

        [TestCleanup]
        public void StopServer()
        {
            _httpClient?.Dispose();
            _httpClient = null;
            if (_host != null)
            {
                _host.Dispose();
                _host = null;
            }
        }
    }
}