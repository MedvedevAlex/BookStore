using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceDB.Models;
using DBLayerAPI.PainterLayers;

namespace API.EntityService.PainterRepos
{
    public class PainterRepository : IPainterRepository
    {
        private readonly IPainterLayer _painerLayer;

        public PainterRepository(IPainterLayer painerLayer)
        {
            _painerLayer = painerLayer;
        }

        public async Task<ICollection<Painter>> SearchByPaintersAsync(string searchString)
        {
            return await _painerLayer.SearchByPaintersAsync(searchString);
        }
    }
}
