using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Painters;
using ViewModel.Responses;
using ViewModel.Responses.Painters;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPainterHandler
    {
        Task<PainterViewModel> AddAsync(PainterModifyModel painter);
        Task<PainterViewModel> UpdateAsync(PainterModifyModel painter);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<PainterViewModel> GetAsync(Guid id);
        Task<PainterPreviewResponse> GetAsync(int takeCount, int skipCount);
        Task<PainterPreviewResponse> SearchByNameAsync(string painterName, int takeCount, int skipCount);
        Task<PainterPreviewResponse> SearchByStyleAsync(string styleName, int takeCount, int skipCount);
    }
}