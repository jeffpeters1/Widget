using Widget.CORE.Entities;

namespace Widget.CORE.Interfaces
{
    public interface IBillGenerator
    {
        string ProcessRectangle(Entities.Rectangle rectangle);
        string ProcessSquare(Square square);
        string ProcessEllipse(Ellipse ellipse);
        string ProcessCircle(Circle circle);
        string ProcessTextbox(Textbox textbox);
    }
}
