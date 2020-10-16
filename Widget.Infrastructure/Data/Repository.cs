using System.Collections.Generic;
using Widget.CORE.Enums;
using Widget.CORE.Interfaces;
using Widget.CORE.Widgets;

namespace Widget.Infrastructure.Data
{
    public class Repository : IRepository
    {
        private readonly List<WidgetSpec> HARDCODED_WIDGET_SPEC_LIST = new List<WidgetSpec>()
        {
            new WidgetSpec(){ ShapeType=ShapeType.Rectangle, PositionX=10, PositionY=10, Width=30, Height=40 },
            new WidgetSpec(){ ShapeType=ShapeType.Square, PositionX=15, PositionY=30, Width=35 },
            new WidgetSpec(){ ShapeType=ShapeType.Ellipse, PositionX=100, PositionY=150, HorizontalDiameter=300, VerticalDiameter=200},
            new WidgetSpec(){ ShapeType=ShapeType.Circle ,PositionX=1, PositionY=1, Diameter=300 },
            new WidgetSpec(){ ShapeType=ShapeType.Textbox, PositionX=5, PositionY=5, Width=200, Height=100, Text="The obligatory Hello World!!" }
        };

        public List<WidgetSpec> ListAll()
        {
            return HARDCODED_WIDGET_SPEC_LIST;
        }
    }
}
