using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.WebPublisher;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly IWebPublisherScenario _webPublisherScenario;

        public PublisherController(IWebPublisherScenario webPublisherScenario)
        {
            _webPublisherScenario = webPublisherScenario;
        }

        [HttpGet("SearchByPublishers")]
        public async Task<ICollection<Publisher>> SearchByPublishersAsync([FromQuery]string searchString)
        {
            return await _webPublisherScenario.SearchByPublishersAsync(searchString);
        }
    }
}
