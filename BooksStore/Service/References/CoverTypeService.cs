using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers.References;
using ViewModel.Interfaces.Services.References;
using ViewModel.Models.References;

namespace Service.References
{
    public class CoverTypeService : ICoverTypeService
    {
        private readonly ICoverTypeHandler _coverTypeHandler;

        public CoverTypeService(ICoverTypeHandler coverTypeHandler)
        {
            _coverTypeHandler = coverTypeHandler;
        }

        public async Task<CoverTypeModel> GetAsync(Guid id)
        {
            return await _coverTypeHandler.GetAsync(id);
        }
    }
}
