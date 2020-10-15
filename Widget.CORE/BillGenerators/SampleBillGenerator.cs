using Widget.CORE.Entities;
using Widget.CORE.Interfaces;

namespace Widget.CORE.BillGenerators
{
    public class SampleBillGenerator : IBillGenerator
    {
        public string ProcessCircle(Circle circle)
        {
            return ($">>> CIRCLE : (X={circle.PositionX},Y={circle.PositionY}) SIZE={circle.VerticalDiameter}");
        }

        public string ProcessEllipse(Ellipse ellipse)
        {
            return ($">>> ELLIPSE : (X={ellipse.PositionX},Y={ellipse.PositionY}) HORIZONTAL_DIAMETER={ellipse.HorizontalDiameter} VERTICAL_DIAMETER={ellipse.VerticalDiameter}");
        }

        public string ProcessRectangle(Rectangle rectangle)
        {
            return ($">>> RECTANGLE : (X={rectangle.PositionX},Y={rectangle.PositionY}) WIDTH={rectangle.Width} HEIGHT={rectangle.Height}");
        }

        public string ProcessSquare(Square square)
        {
            return ($">>> SQUARE : (X={square.PositionX},Y={square.PositionY}) SIZE={square.Width}");
        }

        public string ProcessTextbox(Textbox textbox)
        {
            return ($">>> TEXTBOX : (X={textbox.PositionX},Y={textbox.PositionY}) WIDTH={textbox.Width} HEIGHT={textbox.Height} TEXT=\"{textbox.Text}\"");
        }
    }
}
