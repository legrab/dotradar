namespace DotRadar.Common.Results;

#pragma warning disable CA1034 // Extension blocks not yet supported
#pragma warning disable CA1708 // Extension blocks not yet supported
public static class ResultExtensions
{
    public static Result AsResult(this bool isSuccess, string? errorMessage = null) =>
        isSuccess ? new SuccessResult() : new FailureResult(errorMessage ?? "Operation failed");

    extension<T>(T? value)
    {
        public Result<T?> AsResult(ResultStatus status, string? errorMessage = null) =>
            status is ResultStatus.Success
                ? new SuccessResult<T?>(value)
                : new FailureResult<T?>(errorMessage ?? "Operation failed");

        public Result<T?> AsResult(bool success, string? errorMessage = null) =>
            value.AsResult(success ? ResultStatus.Success : ResultStatus.Failure, errorMessage);

        public SuccessResult<T?> AsSuccess() => new(value);

        public FailureResult<T?> AsFailure(Exception error) => new(error, value);
        public FailureResult<T?> AsFailure(string errorMessage) => new(errorMessage, value);
    }

    extension(object? value)
    {
        public SuccessResult AsSuccess() => new(value);
        public FailureResult AsFailure(Exception error) => new(error, value);
        public FailureResult AsFailure(string errorMessage) => new(errorMessage, value);
    }

    extension(Exception error)
    {
        public FailureResult AsFailure() => new(error);
        public FailureResult<T?> AsFailure<T>() => new(error);
    }
}
#pragma warning restore CA1034
#pragma warning restore CA1708
