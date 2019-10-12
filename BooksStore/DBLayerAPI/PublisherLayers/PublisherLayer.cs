using InterfaceDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DBLayerAPI.PublisherLayers
{
    public class PublisherLayer : IPublisherLayer
    {
        private readonly BookContext _context;

        public PublisherLayer(BookContext context)
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
