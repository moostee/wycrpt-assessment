namespace TransactionService.Application.Contracts.Commands;

public abstract record InternalCommandBase : ICommand
{
    public Guid Id { get; }

    protected InternalCommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected InternalCommandBase(Guid id)
    {
        this.Id = id;
    }
}

public record InternalCommandBase<TResult> : ICommand<TResult>
{
    public Guid Id { get; }

    protected InternalCommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected InternalCommandBase(Guid id)
    {
        this.Id = id;
    }
}
