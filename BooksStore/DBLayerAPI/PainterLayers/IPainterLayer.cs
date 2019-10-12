using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBLayerAPI.PainterLayers
{
    public interface IPainterLayer
    {
        Task<ICollection<Painter>> SearchByPaintersAsync(string searchString);
    }
}