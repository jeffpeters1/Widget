using Widget.CORE.Enums;

namespace Widget.CORE.Interfaces
{
    public interface IBillFactoryService
    {
        IBillGenerator Create(BuilderType builderType);
    }
}
