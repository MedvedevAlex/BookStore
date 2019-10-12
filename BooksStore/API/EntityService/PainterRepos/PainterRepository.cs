using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceDB.Models;
using DBLayerAPI.PainterLayers;
using System.Linq;
using API.Converters;
using API.Models;

namespace API.EntityService.PainterRepos
{
    public class PainterRepository : IPainterRepository
    {
        private readonly IPainterLayer _painerLayer;

        public PainterRepository(IPainterLayer painerLayer)
        {
            _painerLayer = painerLayer;
        }

        public async Task<IEnumerable<PainterModel>> SearchByPaintersAsync(string searchString)
        {
            return (await _painerLayer.SearchByPaintersAsync(searchString)).Select(x => x.ToPainterModel());
        }
    }
}
