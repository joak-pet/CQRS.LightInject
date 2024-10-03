using System.Threading;
using System.Threading.Tasks;
using CQRS.Command.Abstractions;

namespace CQRS.LightInject.Tests;

public class SampleOpenGenericCommandCommandHandler : SampleOpenGenericCommandCommandHandlerBase<SampleOpenGenericCommandDataType> { }

public abstract class SampleOpenGenericCommandCommandHandlerBase<TSampleOpenGenericCommandDataType> : ICommandHandler<ISampleOpenGenericCommand<TSampleOpenGenericCommandDataType>>
    where TSampleOpenGenericCommandDataType : ISampleOpenGenericCommandDataType
{
    public Task HandleAsync(ISampleOpenGenericCommand<TSampleOpenGenericCommandDataType> command, CancellationToken cancellationToken = default)
    {
        command.WasHandled = true;
        return Task.CompletedTask;
    }
}



public class SampleOpenGenericCommand : ISampleOpenGenericCommand<SampleOpenGenericCommandDataType>
{
    public bool WasHandled { get; set; }
}

public interface ISampleOpenGenericCommand<TSampleOpenGenericCommandDataType> where TSampleOpenGenericCommandDataType : ISampleOpenGenericCommandDataType
{
    bool WasHandled { get; set; }
}

public class SampleOpenGenericCommandDataType : ISampleOpenGenericCommandDataType { }

public interface ISampleOpenGenericCommandDataType { }
