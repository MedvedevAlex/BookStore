using BooksStore.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookStoreClient
{
    public class BookClient : IBookClient
    {
        private readonly HttpClient _client; 

        public BookClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<Book> CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> EditBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var response = await _client.GetAsync("/api/book");
            
            try
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<IEnumerable<Book>>(await response.Content.ReadAsStringAsync());
            }
            catch
            {
                return new List<Book>();
            }
        }

        public async Task<Book> GetBook(int id)
        {
            var response = await _client.GetAsync($"/api/book/{id}");

            try
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
            }
            catch
            {
                return new Book();
            }
        }
    }
}