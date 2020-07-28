using System;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Authors;

namespace Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorHandler _authorHandler;

        public AuthorService(IAuthorHandler authorHandler)
        {
            _authorHandler = authorHandler;
        }

        public async Task<AuthorViewModel> GetAsync(Guid id)
        {
            return await _authorHandler.GetAsync(id);
        }
    }
}
