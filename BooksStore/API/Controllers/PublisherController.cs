using System.Collections.Generic;
using System.Threading.Tasks;
using API.EntityService.PublisherRepos;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet("SearchByPublishers")]
        public async Task<ICollection<Publisher>> SearchByPublishersAsync([FromQuery]string searchString)
        {
            return await _publisherRepository.SearchByPublishersAsync(searchString);
        }
    }
}
