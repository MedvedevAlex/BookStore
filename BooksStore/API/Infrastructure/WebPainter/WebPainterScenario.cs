using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using API.Converters;
using API.Models;
using ServiceDb.PainterRepos;

namespace API.Infrastructure.WebPainter
{
    public class WebPainterScenario : IWebPainterScenario
    {
        private readonly IPainterRepository _painterRepository;

        public WebPainterScenario(IPainterRepository painterRepository)
        {
            _painterRepository = painterRepository;
        }

        public async Task<IEnumerable<PainterModel>> SearchByPaintersAsync(string searchString)
        {
            return (await _painterRepository.SearchByPaintersAsync(searchString)).Select(x => x.ToPainterModel());
        }
    }
}
