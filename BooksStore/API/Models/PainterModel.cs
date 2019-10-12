using InterfaceDB.Enums;

namespace API.Models
{
    public class PainterModel
    {
        public int PainterId { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public Style Style { get; set; }
    }
}
