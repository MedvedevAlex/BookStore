using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using ViewModel.Interfaces.Handlers;

namespace Service.PainterRepos
{
    public class PainterHandler : IPainterHandler
    {
        private readonly BookContext _context;

        public PainterHandler(BookContext context)
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
