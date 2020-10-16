using System;
using Widget.CORE.Exceptions;

namespace Widget.CORE.Entities
{
    public class Rectangle : Shape
    {
        // Fields 
        private int width;
        private int height;

        // Properties
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;

                try
                {
                    ValidateWidth();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;

                try
                {
                    ValidateHeight();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // Constructor
        public Rectangle(int positionX, int positionY, int width, int height) : base(positionX, positionY)
        {
            Width = width;
            Height = height;
        }

        // Method
        public override string ProduceBill()
        {
            return $"Rectangle ({this.PositionX},{this.PositionY}) width={this.Width} height={this.Height}";
        }

        // Validation
        private void ValidateHeight()
        {
            if (IsInvalidHeight())
                throw new InvalidMeasurementException();

            bool IsInvalidHeight()
            {
                return height <= 0 || this.PositionY + height > 1000;
            }
        }

        private void ValidateWidth()
        {
            if (IsInvalidWidth())
                throw new InvalidMeasurementException();

            bool IsInvalidWidth()
            {
                return width <= 0 || this.PositionX + width > 1000;
            }
        }
    }
}
