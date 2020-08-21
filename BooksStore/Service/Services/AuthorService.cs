using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Authors;
using ViewModel.Responses;
using ViewModel.Responses.Authors;

namespace Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorHandler _authorHandler;

        public AuthorService(IAuthorHandler authorHandler)
        {
            _authorHandler = authorHandler;
        }

        public async Task<AuthorViewResponse> AddAsync(AuthorModifyModel author)
        {
            try
            {
                return new AuthorViewResponse()
                {
                    Author = await _authorHandler.AddAsync(author)
                };
            }
            catch (Exception e)
            {
                return new AuthorViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<AuthorViewResponse> UpdateAsync(AuthorModifyModel author)
        {
            try
            {
                return new AuthorViewResponse()
                {
                    Author = await _authorHandler.UpdateAsync(author)
                };
            }
            catch (Exception e)
            {
                return new AuthorViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            try
            {
                return await _authorHandler.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return new BaseResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<AuthorViewResponse> GetAsync(Guid id)
        {
            try
            {
                return new AuthorViewResponse()
                {
                    Author = await _authorHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new AuthorViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<AuthorPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            try
            {
                return await _authorHandler.GetAsync(takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new AuthorPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<AuthorPreviewResponse> SearchByNameAsync(string authorName, int takeCount, int skipCount)
        {
            try
            {
                return await _authorHandler.SearchByNameAsync(authorName, takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new AuthorPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
