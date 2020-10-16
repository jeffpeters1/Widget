using System.Collections.Generic;
using Widget.CORE.Widgets;

namespace Widget.CORE.Interfaces
{
    public interface IRepository
    {
        List<WidgetSpec> ListAll();
    }
}
