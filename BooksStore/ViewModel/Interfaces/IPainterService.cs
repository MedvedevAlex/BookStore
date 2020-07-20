using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel.PainterRepos
{
    public interface IPainterService
    {
        Task<ICollection<Painter>> SearchByPaintersAsync(string searchString);
    }
}