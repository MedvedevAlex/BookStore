﻿using System.Collections.Generic;
using System.Threading.Tasks;
using InterfaceDB.Models;

namespace ServiceDb.BookRepos
{
    public interface IBookRepository
    {
        Task CreateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task EditBook(int id, Book book);
        Task<Book> GetBookByIdAsync(int id);
        IEnumerable<Book> GetBooks();
        Task<ICollection<Book>> SearchByAuthorsAsync(string searchString);
        Task<ICollection<Book>> SearchByBooksNameAsync(string searchString);
        Task<ICollection<Book>> SearchByBooksDescriptionAsync(string searchString);
        Task<ICollection<Book>> SearchByGenreAsync(string searchString);
    }
}