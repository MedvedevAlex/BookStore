using System;
using System.Threading.Tasks;
using ViewModel.Models.References;

namespace ViewModel.Interfaces.Handlers.References
{
    public interface IPainterStyleHandler
    {
        Task<PainterStyleModel> AddAsync(PainterStyleModel painterStyle);
        Task<PainterStyleModel> UpdateAsync(PainterStyleModel painterStyle);
        void DeleteAsync(Guid id);
        Task<PainterStyleModel> GetAsync(Guid id);
    }
}