using API.Models;
using InterfaceDB.Models;

namespace API.Converters
{
    public static partial class MappingExtensions
    {
        public static PainterModel ToPainterModel(this Painter painter)
            => new PainterModel
            {
                PainterId = painter.PainterId,
                Name = painter.Name,
                Age = painter.Age,
                Style = painter.Style
            };
    }
}
