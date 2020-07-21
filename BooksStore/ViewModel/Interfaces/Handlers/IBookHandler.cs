﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Models;

namespace ViewModel.Handlers
{
    public interface IBookHandler
    {
        Task AddAsync(BookModel book);
        Task DeleteAsync(int id);
        Task UpdateAsync(BookModel book);
        IEnumerable<BookModel> Get(int takeCount, int skipCount);
        Task<BookModel> GetByIdAsync(int id);
        IEnumerable<BookModel> SearchByAuthor(string searchString);
        IEnumerable<BookModel> SearchByName(string searchString, int takeCount, int skipCount);
        IEnumerable<BookModel> SearchByGenre(string searchString, int takeCount, int skipCount);
    }
}