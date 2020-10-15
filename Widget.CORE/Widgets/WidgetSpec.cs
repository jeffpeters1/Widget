using Widget.CORE.Enums;

namespace Widget.CORE.Widgets
{
    public class WidgetSpec
    {
        public ShapeType ShapeType { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Diameter { get; set; }
        public int HorizontalDiameter { get; set; }
        public int VerticalDiameter { get; set; }
        public string Text { get; set; }

        public override string ToString() => $"{this.GetType()}";
    }
}
