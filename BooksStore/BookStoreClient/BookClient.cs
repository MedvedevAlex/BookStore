using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using InterfaceDB.Models;
using System;

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
            if (book == null)
            {
                return new Book();
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8);
            var response = await _client.PostAsync("/api/book", httpContent);

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

        public async Task<bool> DeleteBook(int id)
        {
            if (id == 0)
            {
                return false;
            }

            var response = await _client.DeleteAsync($"/api/book/{id}");

            try
            {
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Book> EditBook(Book book)
        {
            if (book == null)
            {
                return new Book();
            }

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8);
            var response = await _client.PutAsync($"/api/book/{book.BookId}", httpContent);

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

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {      
            var response = await _client.GetAsync("/api/book");

            try
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<IEnumerable<Book>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return new List<Book>();
            }
        }

        public async Task<Book> GetBookById(int id)
        {
            if (id == 0)
            {
                return new Book();
            }

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