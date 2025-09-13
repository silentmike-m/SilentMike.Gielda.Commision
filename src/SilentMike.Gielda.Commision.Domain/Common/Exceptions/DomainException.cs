namespace SilentMike.Gielda.Commision.Domain.Common.Exceptions;

public abstract class DomainException : Exception
{
    public abstract string Code { get; }
    public Guid Id { get; protected init; } = Guid.Empty;

    protected DomainException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
