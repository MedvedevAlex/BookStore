using InterfaceDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDB.JoinTables
{
    public class PainterBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int PainterId { get; set; }
        public Painter Painter { get; set; }
    }
}
