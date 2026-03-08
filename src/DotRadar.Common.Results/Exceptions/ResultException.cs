namespace DotRadar.Common.Results.Exceptions;

public class ResultException : Exception
{
    public ResultException()
    {
    }

    public ResultException(string message)
        : base(message)
    {
    }

    public ResultException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public override string ToString() =>
        InnerException is null
            ? Message
            : $"{Message} ---> {InnerException}";
}
