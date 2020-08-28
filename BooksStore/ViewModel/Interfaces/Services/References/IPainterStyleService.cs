using System;
using System.Threading.Tasks;
using ViewModel.Models.References;
using ViewModel.Responses;
using ViewModel.Responses.References;

namespace ViewModel.Interfaces.Services.References
{
    public interface IPainterStyleService
    {
        Task<PainterStyleResponse> AddAsync(PainterStyleModel painterStyle);
        Task<PainterStyleResponse> UpdateAsync(PainterStyleModel painterStyle);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<PainterStyleResponse> GetAsync(Guid id);
        Task<ListPainterStylesResponse> GetAsync();
        Task<ListPainterStylesResponse> SearchByNameAsync(string painterStyleName);
    }
}