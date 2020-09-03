using System;
using System.Threading.Tasks;
using ViewModel.Models.References;
using ViewModel.Responses;
using ViewModel.Responses.References.CoverTypes;

namespace ViewModel.Interfaces.Services.References
{
    public interface ICoverTypeService
    {
        Task<CoverTypeResponse> AddAsync(CoverTypeModel coverType);
        Task<CoverTypeResponse> UpdateAsync(CoverTypeModel coverType);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<CoverTypeResponse> GetAsync(Guid id);
        Task<ListCoverTypesResponse> GetAsync();
        Task<ListCoverTypesResponse> SearchByNameAsync(string coverTypeName);
    }
}