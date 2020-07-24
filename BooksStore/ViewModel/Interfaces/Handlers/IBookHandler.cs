﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Books;

namespace ViewModel.Handlers
{
    public interface IBookHandler
    {
        Task AddAsync(BookCreateModel book);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(BookModel book);
        Task<List<BookPreviewModel>> GetAsync(int takeCount, int skipCount);
        Task<BookViewModel> GetByIdAsync(Guid id);
        IEnumerable<BookModel> SearchByAuthor(string searchString);
        IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount);
        //IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount);
    }
}