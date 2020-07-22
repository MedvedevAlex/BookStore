using System;

namespace Model.Entities
{
    public class PainterBook
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid PainterId { get; set; }
        public Painter Painter { get; set; }
    }
}
