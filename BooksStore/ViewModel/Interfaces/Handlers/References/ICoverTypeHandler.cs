using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.References;

namespace ViewModel.Interfaces.Handlers.References
{
    public interface ICoverTypeHandler
    {
        Task<CoverTypeModel> AddAsync(CoverTypeModel coverType);
        Task<CoverTypeModel> UpdateAsync(CoverTypeModel coverType);
        void DeleteAsync(Guid id);
        Task<CoverTypeModel> GetAsync(Guid id);
        Task<List<CoverTypeModel>> GetAsync();
    }
}