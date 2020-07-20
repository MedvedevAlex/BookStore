using InterfaceDB.Enums;
using InterfaceDB.JoinTables;
using System.Collections.Generic;

namespace InterfaceDB.Models
{
    public class Painter
    {
        public int PainterId { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public Style Style { get; set; }

        public ICollection<PainterBook> PainterBooks { get; } = new List<PainterBook>();
    }
}