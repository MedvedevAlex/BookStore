using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Authors;

namespace ViewModel.Handlers
{
    public interface IAuthorHandler
    {
        Task<AuthorViewModel> GetAsync(Guid id);
        Task<List<AuthorPreviewModel>> GetAsync(int takeCount, int skipCount);
    }
}