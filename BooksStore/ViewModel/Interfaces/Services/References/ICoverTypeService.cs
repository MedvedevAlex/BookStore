using System;
using System.Threading.Tasks;
using ViewModel.Models.References;

namespace ViewModel.Interfaces.Services.References
{
    public interface ICoverTypeService
    {
        Task<CoverTypeModel> GetAsync(Guid id);
    }
}