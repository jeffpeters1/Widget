using Widget.CORE.BillGenerators;
using Widget.CORE.Enums;
using Widget.CORE.Exceptions;
using Widget.CORE.Interfaces;

namespace Widget.CORE.Services
{
    public class BillFactoryService : IBillFactoryService
    {
        public IBillGenerator Create(BuilderType builderType)
        {
            return builderType switch
            {
                BuilderType.Legacy => new LegacyBillGenerator(),
                BuilderType.Sample => new SampleBillGenerator(),
                _ => throw new UnknownBuilderException(),
            };
        }
    }
}
