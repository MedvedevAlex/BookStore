using System;
using System.Threading.Tasks;
using ViewModel.Models.References;

namespace ViewModel.Interfaces.Handlers.References
{
    public interface ICoverTypeHandler
    {
        Task<CoverTypeModel> GetAsync(Guid id);
    }
}