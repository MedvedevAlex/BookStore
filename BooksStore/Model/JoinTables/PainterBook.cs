using Model.Models;

namespace Model.JoinTables
{
    public class PainterBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int PainterId { get; set; }
        public Painter Painter { get; set; }
    }
}
