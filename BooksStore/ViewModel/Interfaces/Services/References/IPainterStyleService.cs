using System;
using System.Threading.Tasks;
using ViewModel.Models.References;

namespace ViewModel.Interfaces.Services.References
{
    public interface IPainterStyleService
    {
        Task<PainterStyleModel> AddAsync(PainterStyleModel painterStyle);
        Task<PainterStyleModel> UpdateAsync(PainterStyleModel painterStyle);
        void Delete(Guid id);

        Task<PainterStyleModel> GetAsync(Guid id);
    }
}