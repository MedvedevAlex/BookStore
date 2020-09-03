using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.References;
using ViewModel.Responses;
using ViewModel.Responses.References.CoverTypes;

namespace ViewModel.Interfaces.Handlers.References
{
    public interface ICoverTypeHandler
    {
        Task<CoverTypeModel> AddAsync(CoverTypeModel coverType);
        Task<CoverTypeModel> UpdateAsync(CoverTypeModel coverType);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<CoverTypeModel> GetAsync(Guid id);
        Task<ListCoverTypesResponse> GetAsync();
        Task<ListCoverTypesResponse> SearchByNameAsync(string coverTypeName);
    }
}