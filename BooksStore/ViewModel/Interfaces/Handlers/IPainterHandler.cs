using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPainterHandler
    {
        Task<ICollection<Painter>> SearchByPaintersAsync(string searchString);
    }
}