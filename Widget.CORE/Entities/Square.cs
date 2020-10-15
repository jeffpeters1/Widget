using System;
using Widget.CORE.Interfaces;

namespace Widget.CORE.Entities
{
    public class Square : Rectangle
    {
        public Square(int positionX, int positionY, int width) : base(positionX, positionY, width, width)
        {
        }
    }
}
