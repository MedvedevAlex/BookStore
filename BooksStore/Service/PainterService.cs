using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Service.PainterRepos
{
    public class PainterService : IPainterService
    {
        private readonly BookContext _context;

        public PainterService(BookContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Painter>> SearchByPaintersAsync(string searchString)
        {
            return await (from painter in _context.Painters
                          where painter.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                          select painter).ToListAsync();
        }
    }
}
