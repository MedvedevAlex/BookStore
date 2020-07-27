using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers.References;
using ViewModel.Interfaces.Services.References;
using ViewModel.Models.References;

namespace Service.References
{
    public class PainterStyleService : IPainterStyleService
    {
        private readonly IPainterStyleHandler _painterStyleHandler;

        public PainterStyleService(IPainterStyleHandler painterStyleHandler)
        {
            _painterStyleHandler = painterStyleHandler;
        }

        public async Task<PainterStyleModel> AddAsync(PainterStyleModel painterStyle)
        {
            return await _painterStyleHandler.AddAsync(painterStyle);
        }

        public async Task<PainterStyleModel> UpdateAsync(PainterStyleModel painterStyle)
        {
            return await _painterStyleHandler.UpdateAsync(painterStyle);
        }
        public void Delete(Guid id)
        {
            _painterStyleHandler.DeleteAsync(id);
        }

        public async Task<PainterStyleModel> GetAsync(Guid id)
        {
            return await _painterStyleHandler.GetAsync(id);
        }

        public async Task<List<PainterStyleModel>> GetAsync()
        {
            return await _painterStyleHandler.GetAsync();
        }
    }
}
