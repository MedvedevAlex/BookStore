using System;
using System.Threading.Tasks;
using ViewModel.Models.References;
using ViewModel.Responses;
using ViewModel.Responses.References;

namespace ViewModel.Interfaces.Handlers.References
{
    public interface IPainterStyleHandler
    {
        Task<PainterStyleModel> AddAsync(PainterStyleModel painterStyle);
        Task<PainterStyleModel> UpdateAsync(PainterStyleModel painterStyle);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<PainterStyleModel> GetAsync(Guid id);
        Task<ListPainterStylesResponse> GetAsync();
        Task<ListPainterStylesResponse> SearchByNameAsync(string painterStyleName);
    }
}