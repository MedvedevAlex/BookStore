using System.Collections.Generic;
using ViewModel.Interfaces.Services;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models;

namespace Service.PainterRepos
{
    public class PainterService : IPainterService
    {
        private readonly IPainterHandler _painterHandler;

        public PainterService(IPainterHandler painterHandler)
        {
            _painterHandler = painterHandler;
        }

        public IEnumerable<PainterModel> SearchByName(string painterName, int takeCount, int skipCount)
        {
            return _painterHandler.SearchByName(painterName, takeCount, skipCount);
        }
    }
}
