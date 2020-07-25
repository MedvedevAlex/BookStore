using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Painters;

namespace ViewModel.Interfaces.Services
{
    public interface IPainterService
    {
        Task<PainterViewModel> GetAsync(Guid id);
        Task<List<PainterViewModel>> GetAsync(int takeCount, int skipCount);
        Task<PainterViewModel> AddAsync(PainterCreateModel painter);
        Task<List<PainterViewModel>> SearchByNameAsync(string painterName, int takeCount, int skipCount);
    }
}