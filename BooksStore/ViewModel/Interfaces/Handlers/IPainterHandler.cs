using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Painters;

namespace ViewModel.Interfaces.Handlers
{
    public interface IPainterHandler
    {
        Task<PainterViewModel> AddAsync(PainterModifyModel painter);
        Task<PainterViewModel> UpdateAsync(PainterModifyModel painter);
        Task<PainterViewModel> GetAsync(Guid id);
        Task<List<PainterViewModel>> GetAsync(int takeCount, int skipCount);
        Task<List<PainterViewModel>> SearchByNameAsync(string painterName, int takeCount, int skipCount);
    }
}