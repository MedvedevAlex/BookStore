﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models.Books;

namespace ViewModel.Interfaces.Services
{
    public interface IBookService
    {
        Task Add(BookCreateModel book);
        Task Delete(Guid id);
        Task Update(BookCreateModel book);
        Task<BookViewModel> GetByIdAsync(Guid id);
        Task<List<BookPreviewModel>> GetAsync(int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByAuthor(string searchString);
        //IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount);
    }
}