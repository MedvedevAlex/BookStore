﻿using DBLayerAPI;
using InterfaceDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EntityService
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookLayer _bookLayer;

        public BookRepository(IBookLayer bookLayer)
        {
            _bookLayer = bookLayer;
        }
        
        public IEnumerable<Book> GetBooks() 
            => _bookLayer.GetBooks();

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookLayer.GetBookByIdAsync(id);
        }

        public async Task CreateBookAsync(Book book) 
        {
            await _bookLayer.CreateBookAsync(book);
        }

        public async Task EditBookAsync(int id, Book book)
        {
            await _bookLayer.EditBook(id, book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookLayer.DeleteBookAsync(id);
        }

        public async Task<ICollection<Book>> SearchByAuthorsAsync(string searchString)
        {
            return await _bookLayer.SearchByAuthorsAsync(searchString);
        }

        public async Task<ICollection<Book>> SearchByBooksNameAsync(string searchString)
        {
            return await _bookLayer.SearchByBooksNameAsync(searchString);
        }

        public async Task<ICollection<Book>> SearchByGenreAsync(string searchString)
        {
            return await _bookLayer.SearchByGenreAsync(searchString);
        }

        public async Task<ICollection<Book>> SearchByBooksDescriptionAsync(string searchString)
        {
            return await _bookLayer.SearchByBooksDescriptionAsync(searchString);
        }
    }
}
