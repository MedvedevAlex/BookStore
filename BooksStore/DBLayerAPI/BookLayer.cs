﻿using InterfaceDB.Enums;
using InterfaceDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBLayerAPI
{
    public class BookLayer : IBookLayer
    {
        private readonly BookContext _context;

        public BookLayer(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task CreateBookAsync(Book book)
        {
            try
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при добавлении в базу данных", e);
            }
            
        }

        public async Task EditBook(int id, Book book)
        {
            try
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при сохранении в базу данных", e);
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            try
            {
                Book book = await _context.Books.FindAsync(id);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка при сохранении в базу данных", e);
            }
        }

        public async Task<ICollection<Book>> SearchByAuthorsAsync(string searchString)
        {
            return await (from author in _context.Authors
                          join authorbook in _context.AuthorBooks on author.AuthorId equals authorbook.AuthorId
                          join book in _context.Books on authorbook.BookId equals book.BookId
                          where author.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select book).ToListAsync();
        }

        public async Task<ICollection<Book>> SearchByBooksAsync(string searchString)
        {
            return await (from book in _context.Books
                          where book.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select book).ToListAsync();
        }

        public async Task<ICollection<Book>> SearchByGenreAsync(string searchString)
        {
            var genreStringSearch = DictionariesSupport.ConvertGenreRus
                .Where(s => s.Value.StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Key);

            if (genreStringSearch.Count() == 0)
            {
                return new List<Book>();
            }

            return await (from book in _context.Books
                          where book.Genre.Equals(genreStringSearch.FirstOrDefault())
                          select book).ToListAsync();
        }

        public async Task<ICollection<Book>> SearchByBooksDescriptionAsync(string searchString)
        {
            return await (from book in _context.Books
                          where book.Description.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select book).ToListAsync();
        }

        public async Task<ICollection<Painter>> SearchByPaintersAsync(string searchString)
        {
            return await (from painter in _context.Painters
                          where painter.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select painter).ToListAsync();
        }

        public async Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString)
        {
            return await (from publisher in _context.Publishers
                          where publisher.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select publisher).ToListAsync();
        }
    }
}
