using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Handlers;
using ViewModel.Interfaces.Services;
using ViewModel.Models.Books;

namespace Service.BookRepos
{
    public class BookService : IBookService
    {
        private readonly IBookHandler _bookHandler;

        public BookService(IBookHandler bookHandler)
        {
            _bookHandler = bookHandler;
        }

        public async Task<List<BookPreviewModel>> GetAsync(int takeCount, int skipCount)
        {
            return await _bookHandler.GetAsync(takeCount, skipCount);
        }

        public async Task<BookViewModel> GetAsync(Guid id)
        {
            return await _bookHandler.GetAsync(id);
        }

        public async Task<BookViewModel> AddAsync(BookCreateModel book)
        {
            return await _bookHandler.AddAsync(book);
        }

        public async Task<BookViewModel> UpdateAsync(BookCreateModel book)
        {
            return await _bookHandler.UpdateAsync(book);
        }

        public Task Delete(Guid id)
        {
            return _bookHandler.DeleteAsync(id);
        }

        public async Task<List<BookPreviewModel>> SearchByAuthorAsync(string searchString, int takeCount, int skipCount)
        {
            return await _bookHandler.SearchByAuthorAsync(searchString, takeCount, skipCount);
        }

        public async Task<List<BookPreviewModel>> SearchByNameAsync(string searchString, int takeCount, int skipCount)
        {
            return await _bookHandler.SearchByNameAsync(searchString, takeCount, skipCount);
        }

        public async Task<List<BookPreviewModel>> SearchByGenreAsync(string searchString, int takeCount, int skipCount)
        {
            return await _bookHandler.SearchByGenreAsync(searchString, takeCount, skipCount);
        }
    }
}
