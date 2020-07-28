using System;
using System.Threading.Tasks;
using ViewModel.Models.Authors;

namespace ViewModel.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<AuthorViewModel> GetAsync(Guid id);
    }
}