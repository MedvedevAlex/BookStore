using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Authors;

namespace ViewModel.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<AuthorViewModel> AddAsync(AuthorModifyModel author);
        Task<AuthorViewModel> UpdateAsync(AuthorModifyModel author);
        Task<AuthorViewModel> GetAsync(Guid id);
        void Delete(Guid id);
        Task<List<AuthorPreviewModel>> GetAsync(int takeCount, int skipCount);
    }
}