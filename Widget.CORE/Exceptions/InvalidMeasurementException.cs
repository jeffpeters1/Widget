using System;
using Widget.CORE.Entities;

namespace Widget.CORE.Exceptions
{
    [Serializable]
    public class InvalidMeasurementException : Exception
    {
        public InvalidMeasurementException()
        {
        }

        public InvalidMeasurementException(Shape shape, string measurement, int value)
            : base($"Invalid Measurement: Shape = {shape.GetType()}, Measurement={measurement}, Value ={value}")
        {
        }
    }
}


// https://www.tutorialsteacher.com/csharp/custom-exception-csharp