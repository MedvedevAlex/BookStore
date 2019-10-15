using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.WebPainter;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PainterController : Controller
    {
        private readonly IWebPainterScenario  _webPainterScenario;

        public PainterController(IWebPainterScenario webPainterScenario)
        {
            _webPainterScenario = webPainterScenario;
        }

        [HttpGet("SearchByPainters")]
        public async Task<IEnumerable<PainterModel>> SearchByPaintersAsync([FromQuery]string searchString)
        {
            return await _webPainterScenario.SearchByPaintersAsync(searchString);
        }
    }
}
