using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Painters;

namespace ViewModel.Interfaces.Services
{
    public interface IPainterService
    {
        Task<PainterModel> GetAsync(Guid id);
        Task<List<PainterModel>> GetAsync(int takeCount, int skipCount);
        Task<List<PainterModel>> SearchByNameAsync(string painterName, int takeCount, int skipCount);
    }
}