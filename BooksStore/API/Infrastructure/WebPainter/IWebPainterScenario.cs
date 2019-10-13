using API.Models;
using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infrastructure.WebPainter
{
    public interface IWebPainterScenario
    {
        Task<IEnumerable<PainterModel>> SearchByPaintersAsync(string searchString);
    }
}