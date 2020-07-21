using System.Collections.Generic;
using ViewModel.Models;

namespace ViewModel.Interfaces.Services
{
    public interface IPainterService
    {
        IEnumerable<PainterModel> SearchByName(string painterName, int takeCount, int skipCount);
    }
}