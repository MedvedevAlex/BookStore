using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Painters;

namespace ViewModel.Interfaces.Services
{
    public interface IPainterService
    {
        Task<PainterViewModel> AddAsync(PainterModifyModel painter);
        Task<PainterViewModel> UpdateAsync(PainterModifyModel painter);
        void DeleteAsync(Guid id);
        Task<PainterViewModel> GetAsync(Guid id);
        Task<List<PainterPreviewModel>> GetAsync(int takeCount, int skipCount);
        Task<List<PainterPreviewModel>> SearchByNameAsync(string painterName, int takeCount, int skipCount);
        Task<List<PainterPreviewModel>> SearchBySyleAsync(string styleName, int takeCount, int skipCount);
    }
}