namespace DotRadar.Common.Results.Exceptions;

public sealed class UnknownResultException : ResultException
{
    public UnknownResultException()
    {
    }

    public UnknownResultException(string message)
        : base(message)
    {
    }

    public UnknownResultException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
