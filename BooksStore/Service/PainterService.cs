using System.Collections.Generic;
using ViewModel.Interfaces.Services;
using ViewModel.Interfaces.Handlers;
using ViewModel.Models.Painters;
using System.Threading.Tasks;
using System;

namespace Service.PainterRepos
{
    public class PainterService : IPainterService
    {
        private readonly IPainterHandler _painterHandler;

        public PainterService(IPainterHandler painterHandler)
        {
            _painterHandler = painterHandler;
        }

        public async Task<PainterViewModel> AddAsync(PainterModifyModel painter)
        {
            return await _painterHandler.AddAsync(painter);
        }

        public async Task<PainterViewModel> UpdateAsync(PainterModifyModel painter)
        {
            return await _painterHandler.UpdateAsync(painter);
        }

        public void DeleteAsync(Guid id)
        {
            _painterHandler.DeleteAsync(id);
        }

        public async Task<PainterViewModel> GetAsync(Guid id)
        {
            return await _painterHandler.GetAsync(id);
        }

        public async Task<List<PainterViewModel>> GetAsync(int takeCount, int skipCount)
        {
            return await _painterHandler.GetAsync(takeCount, skipCount);
        }

        public async Task<List<PainterViewModel>> SearchByNameAsync(string painterName, int takeCount, int skipCount)
        {
            return await _painterHandler.SearchByNameAsync(painterName, takeCount, skipCount);
        }
    }
}
