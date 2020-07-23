﻿using Model.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Interfaces.Services;
using ViewModel.Models;

namespace Service.BookRepos
{
    public class BookService : IBookService
    {
        private readonly BookHandler _bookHandler;

        public BookService(BookHandler bookHandler)
        {
            _bookHandler = bookHandler;
        }

        public IEnumerable<BookModel> Get(int takeCount, int skipCount)
        {
            return _bookHandler.Get(takeCount, skipCount);
        }

        public async Task<BookModel> GetByIdAsync(Guid id)
        {
            return await _bookHandler.GetByIdAsync(id);
        }

        public Task Add(BookModel book)
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
