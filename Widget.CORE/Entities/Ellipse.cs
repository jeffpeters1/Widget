﻿using System;
using Widget.CORE.Exceptions;
using Widget.CORE.Interfaces;

namespace Widget.CORE.Entities
{
    public class Ellipse : Shape
    {
        // Fields 
        private int horizontalDiameter;
        private int verticalDiameter;

        // Properties
        public int HorizontalDiameter
        {
            get
            {
                return horizontalDiameter;
            }
            set
            {
                try
                {
                    ValidateDiameter(value);
                }
                catch (Exception)
                {
                    throw;
                }

                horizontalDiameter = value;
            }
        }
        public int VerticalDiameter
        {
            get
            {
                return verticalDiameter;
            }
            set
            {
                try
                {
                    ValidateDiameter(value);
                }
                catch (Exception)
                {
                    throw;
                }

                verticalDiameter = value;
            }
        }

        // Constructor
        public Ellipse(int positionX, int positionY, int verticalDiameter, int horizontalDiameter) : base(positionX, positionY)
        {
            VerticalDiameter = verticalDiameter;
            HorizontalDiameter = horizontalDiameter;
        }

        // Method - This method is here for illustration purposes only.  I have chosen to use the factory pattern instead (which I am happy to discuss!!)
        public override string ProduceBill()
        {
            return $"Ellipse ({this.PositionX},{this.PositionY}) diameterH = {this.HorizontalDiameter} diameterV = {this.VerticalDiameter}";
        }

        // Validation
        private void ValidateDiameter(int value)
        {
            if (value <= 0)
                throw new InvalidMeasurementException();
        }
    }
}
