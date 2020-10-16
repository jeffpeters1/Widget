using System;
using Widget.CORE.Exceptions;

namespace Widget.CORE.Entities
{
    public abstract class Shape
    {
        private int positionX;
        private int positionY;

        public int PositionX
        {
            get
            {
                return positionX;
            }
            set
            {
                positionX = value;

                try
                {
                    ValidatePosition(positionX);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public int PositionY
        {
            get
            {
                return positionY;
            }
            set
            {
                positionY = value;

                try
                {
                    ValidatePosition(positionY);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Shape(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        // Methods
        public abstract string ProduceBill();

        // Validation
        private void ValidatePosition(int position)
        {
            if (IsPositionNegative(position))
                throw new InvalidMeasurementException();

            bool IsPositionNegative(int position)
            {
                return position < 0;
            }
        }
    }
}
