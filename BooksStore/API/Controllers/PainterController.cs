using System.Collections.Generic;
using System.Threading.Tasks;
using API.EntityService.PainterRepos;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PainterController : Controller
    {
        private readonly IPainterRepository _painterRepository;

        public PainterController(IPainterRepository painterRepository)
        {
            _painterRepository = painterRepository;
        }

        [HttpGet("SearchByPainters")]
        public async Task<ICollection<Painter>> SearchByPaintersAsync([FromQuery]string searchString)
        {
            return await _painterRepository.SearchByPaintersAsync(searchString);
        }
    }
}
