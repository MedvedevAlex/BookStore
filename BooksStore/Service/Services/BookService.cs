using System;
using System.Threading.Tasks;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Books;
using ViewModel.Responses;
using ViewModel.Responses.Books;

namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookHandler _bookHandler;

        public BookService(IBookHandler bookHandler)
        {
            _bookHandler = bookHandler;
        }

        public async Task<BookViewResponse> AddAsync(BookModifyModel book)
        {
            try
            {
                return new BookViewResponse()
                {
                    Book = await _bookHandler.AddAsync(book)
                };
            }
            catch (Exception e)
            {
                return new BookViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BookViewResponse> UpdateAsync(BookModifyModel book)
        {
            try
            {
                return new BookViewResponse()
                {
                    Book = await _bookHandler.UpdateAsync(book)
                };
            }
            catch (Exception e)
            {
                return new BookViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            try
            {
                return await _bookHandler.DeleteAsync(id);
            }
            catch (Exception e)
            {
                return new BaseResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BookViewResponse> GetAsync(Guid id)
        {
            try
            {
                return new BookViewResponse()
                {
                    Book = await _bookHandler.GetAsync(id)
                };
            }
            catch (Exception e)
            {
                return new BookViewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BookPreviewResponse> GetAsync(int takeCount, int skipCount)
        {
            try
            {
                return await _bookHandler.GetAsync(takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new BookPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BookPreviewResponse> SearchByAuthorAsync(string searchString, int takeCount, int skipCount)
        {
            try
            {
                return await _bookHandler.SearchByAuthorAsync(searchString, takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new BookPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BookPreviewResponse> SearchByNameAsync(string searchString, int takeCount, int skipCount)
        {
            try
            {
                return await _bookHandler.SearchByNameAsync(searchString, takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new BookPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }

        public async Task<BookPreviewResponse> SearchByGenreAsync(string searchString, int takeCount, int skipCount)
        {
            try
            {
                return await _bookHandler.SearchByGenreAsync(searchString, takeCount, skipCount);
            }
            catch (Exception e)
            {
                return new BookPreviewResponse() { Success = false, ErrorMessage = e.Message };
            }
        }
    }
}
