using System.Threading;
using System.Threading.Tasks;
using CQRS.Query.Abstractions;

namespace CQRS.LightInject.Tests;

public class SampleOpenGenericQueryQueryHandler : SampleOpenGenericQueryQueryHandlerBase<SampleOpenGenericQueryDataType> { }

public abstract class SampleOpenGenericQueryQueryHandlerBase<TSampleOpenGenericQueryDataType> : IQueryHandler<ISampleOpenGenericQuery<TSampleOpenGenericQueryDataType>, TSampleOpenGenericQueryDataType>
    where TSampleOpenGenericQueryDataType : ISampleOpenGenericQueryDataType
{
    public Task<TSampleOpenGenericQueryDataType> HandleAsync(ISampleOpenGenericQuery<TSampleOpenGenericQueryDataType> query, CancellationToken cancellationToken = default)
    {
        query.WasHandled = true;
        return Task.FromResult(default(TSampleOpenGenericQueryDataType));
    }
}



public class SampleOpenGenericQuery : ISampleOpenGenericQuery<SampleOpenGenericQueryDataType>
{
    public bool WasHandled { get; set; }
}

public interface ISampleOpenGenericQuery<TSampleOpenGenericQueryDataType> :IQuery<TSampleOpenGenericQueryDataType> where TSampleOpenGenericQueryDataType : ISampleOpenGenericQueryDataType
{
    bool WasHandled { get; set; }
}

public class SampleOpenGenericQueryDataType : ISampleOpenGenericQueryDataType { }

public interface ISampleOpenGenericQueryDataType { }
