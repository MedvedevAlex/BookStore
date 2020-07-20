using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel.Interfaces.Services
{
    public interface IPainterService
    {
        Task<ICollection<Painter>> SearchByPaintersAsync(string searchString);
    }
}