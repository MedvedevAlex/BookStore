using API.Models;
using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EntityService.PainterRepos
{
    public interface IPainterRepository
    {
        Task<IEnumerable<PainterModel>> SearchByPaintersAsync(string searchString)
    }
}