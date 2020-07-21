namespace Model.Models
{
    public class PainterBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int PainterId { get; set; }
        public Painter Painter { get; set; }
    }
}
