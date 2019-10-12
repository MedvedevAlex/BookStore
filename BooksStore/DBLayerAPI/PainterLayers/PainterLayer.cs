using InterfaceDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DBLayerAPI.PainterLayers
{
    public class PainterLayer : IPainterLayer
    {
        private readonly BookContext _context;

        public PainterLayer(BookContext context)
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
