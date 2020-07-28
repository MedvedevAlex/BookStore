using System;
using System.Threading.Tasks;
using ViewModel.Models.Authors;

namespace ViewModel.Handlers
{
    public interface IAuthorHandler
    {
        Task<AuthorViewModel> GetAsync(Guid id);
    }
}