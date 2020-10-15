using System.Collections.Generic;
using Widget.CORE.Enums;

namespace Widget.CORE.Interfaces
{
    public interface IOutputService
    {
        List<string> GetBillOfMaterials(BuilderType builderType);
    }
}
