using Widget.CORE.Interfaces;

namespace Widget.CORE.Entities
{
    public class Textbox : Rectangle
    {
        public string Text { get; set; }

        public Textbox(int positionX, int positionY, int width, int height, string text = "") : base(positionX, positionY, width, height)
        {
            Text = text;
        }
    }
}
