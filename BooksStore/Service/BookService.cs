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

        public async Task<BookViewModel> GetByIdAsync(Guid id)
        {
            return await _bookHandler.GetByIdAsync(id);
        }

        public Task Add(BookCreateModel book)
        {
            return _bookHandler.AddAsync(book);
        }

        public Task Update(BookModel book)
        {
            return _bookHandler.UpdateAsync(book);
        }

        public Task Delete(Guid id)
        {
            return _bookHandler.DeleteAsync(id);
        }

        public IEnumerable<BookModel> SearchByAuthor(string searchString)
        {
            return _bookHandler.SearchByAuthor(searchString);
        }

        public IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount)
        {
            return _bookHandler.SearchByName(searchString, takeCount, skipCount);
        }

        //public IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount)
        //{
        //    return _bookHandler.SearchByGenre(searchString, takeCount, skipCount);
        //}
    }
}
