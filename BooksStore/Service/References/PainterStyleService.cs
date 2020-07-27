using System;
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

        public async Task<PainterStyleModel> GetAsync(Guid id)
        {
            return await _painterStyleHandler.GetAsync(id);
        }
    }
}
