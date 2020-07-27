using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.References;

namespace ViewModel.Interfaces.Services.References
{
    public interface ICoverTypeService
    {
        Task<CoverTypeModel> AddAsync(CoverTypeModel coverType);
        Task<CoverTypeModel> UpdateAsync(CoverTypeModel coverType);
        void Delete(Guid id);
        Task<CoverTypeModel> GetAsync(Guid id);
        Task<List<CoverTypeModel>> GetAsync();
    }
}