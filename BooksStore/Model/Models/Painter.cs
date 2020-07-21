using System.Collections.Generic;
using ViewModel.Enums;

namespace Model.Models
{
    public class Painter
    {
        public int PainterId { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public Style Style { get; set; }

        public virtual ICollection<PainterBook> PainterBooks { get; set; }
    }
}