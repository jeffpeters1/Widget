using Widget.CORE.Entities;
using Widget.CORE.Interfaces;

namespace Widget.CORE.BillGenerators
{
    public class LegacyBillGenerator : IBillGenerator
    {
        public string ProcessCircle(Circle circle)
        {
            return ($"Circle ({circle.PositionX},{circle.PositionY}) size={circle.VerticalDiameter}");
        }

        public string ProcessEllipse(Ellipse ellipse)
        {
            return ($"Ellipse ({ellipse.PositionX},{ellipse.PositionY}) diameterH = {ellipse.HorizontalDiameter} diameterV = {ellipse.VerticalDiameter}");
        }

        public string ProcessRectangle(Rectangle rectangle)
        {
            return($"Rectangle ({rectangle.PositionX},{rectangle.PositionY}) width={rectangle.Width} height={rectangle.Height}");
        }

        public string ProcessSquare(Square square)
        {
            return ($"Square ({square.PositionX},{square.PositionY}) size={square.Width}");
        }

        public string ProcessTextbox(Textbox textbox)
        {
            return ($"Textbox ({textbox.PositionX},{textbox.PositionY}) width={textbox.Width} height={textbox.Height} text=\"{textbox.Text}\"");
        }
    }
}
