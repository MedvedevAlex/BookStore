using System;
using System.Collections.Generic;
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

        public async Task<CoverTypeModel> AddAsync(CoverTypeModel coverType)
        {
            return await _coverTypeHandler.AddAsync(coverType);
        }

        public async Task<CoverTypeModel> UpdateAsync(CoverTypeModel coverType)
        {
            return await _coverTypeHandler.UpdateAsync(coverType);
        }

        public void Delete(Guid id)
        {
            _coverTypeHandler.DeleteAsync(id);
        }

        public async Task<CoverTypeModel> GetAsync(Guid id)
        {
            return await _coverTypeHandler.GetAsync(id);
        }

        public async Task<List<CoverTypeModel>> GetAsync()
        {
            return await _coverTypeHandler.GetAsync();
        }

        public async Task<List<CoverTypeModel>> SearchByNameAsync(string coverTypeName)
        {
            return await _coverTypeHandler.SearchByNameAsync(coverTypeName);
        }
    }
}
