using InterfaceDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServiceDb.PublisherRepos
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookContext _context;

        public PublisherRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Publisher>> SearchByPublishersAsync(string searchString)
        {
            return await (from publisher in _context.Publishers
                          where publisher.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select publisher).ToListAsync();
        }
    }
}
