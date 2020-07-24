using System.Collections.Generic;
using ViewModel.Models.Painters;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPainterHandler
    {
        IEnumerable<PainterModel> SearchByName(string painterName, int takeCount, int skipCount);
    }
}