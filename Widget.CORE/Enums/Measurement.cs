using System.ComponentModel;

namespace Widget.CORE.Enums
{
    public enum Measurement
    {
        Width,
        Height,
        Diameter,
        [Description("Vertical Diameter")]
        VerticalDiameter,
        [Description("Horizontal Diameter")]
        HorizontalDiameter
    }
}
