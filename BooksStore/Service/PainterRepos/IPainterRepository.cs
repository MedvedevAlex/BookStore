using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceDb.PainterRepos
{
    public interface IPainterRepository
    {
        Task<ICollection<Painter>> SearchByPaintersAsync(string searchString);
    }
}