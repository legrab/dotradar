using System.Diagnostics.CodeAnalysis;
using DotRadar.Common.Results.Exceptions;

namespace DotRadar.Common.Results;

/// <summary>
///     Represents the result of an operation.
/// </summary>
public record Result
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Result" /> class.
    /// </summary>
    /// <param name="status">The status of the result.</param>
    /// <param name="value">The value of the result, if any.</param>
    /// <param name="error">The error that occurred, if any.</param>
    public Result(ResultStatus status, object? value = null, Exception? error = null)
    {
        Status = status;
        Value = value;
        Error = error ?? (status == ResultStatus.Failure ? new UnknownResultException() : null);
    }

    /// <summary>
    ///     Gets the status of the result.
    /// </summary>
    public ResultStatus Status { get; init; }

    /// <summary>
    ///     Gets the value of the result, if any.
    /// </summary>
    public object? Value { get; }

    /// <summary>
    ///     Gets the error that occurred, if any.
    /// </summary>
    public Exception? Error { get; init; }

    /// <summary>
    ///     Gets a value indicating whether the operation succeeded.
    /// </summary>
    public bool Succeeded => Status == ResultStatus.Success;

    /// <summary>
    ///     Gets a value indicating whether the operation failed.
    /// </summary>
    public bool Failed => Status == ResultStatus.Failure;

    /// <summary>
    ///     Gets the error message, if any.
    /// </summary>
    public string ErrorMessage => Error?.Message.IsNullOrEmpty() is false
        ? Error.Message
        : Error?.ToString() ?? string.Empty;

#pragma warning disable CA1024
    public object GetValueOrThrow() => Succeeded && Value is not null
#pragma warning restore CA1024
        ? Value
        : throw Error ?? new UnknownResultException();

    public static SuccessResult Success(object? value = null) => new(value);
    public static FailureResult Failure(Exception error, object? value = null) => new(error, value);
    public static FailureResult Failure(string errorMessage, object? value = null) => new(errorMessage, value);

    public static SuccessResult<T> Success<T>(T value) => new(value);
    public static FailureResult<T> Failure<T>(Exception error, T? value = default) => new(error, value);
    public static FailureResult<T> Failure<T>(string errorMessage, T? value = default) => new(errorMessage, value);

    public static Task<Result> ToTask(Result result) => Task.FromResult(result);
    public static implicit operator Task<Result>(Result result) => Task.FromResult(result);

    public static Task<Result<T>> ToTask<T>(Result<T> result) => Task.FromResult(result);


    public static Exception ToException(Result? result) => result?.Error ?? new UnknownResultException();
    public static implicit operator Exception(Result? result) => ToException(result);

    public static FailureResult FromException(Exception error) => new(error);
    public static implicit operator Result(Exception error) => FromException(error);

    public static Exception ToException<T>(Result<T>? result) => result?.Error ?? new UnknownResultException();

    public static FailureResult<T> FromException<T>(Exception error) => new(error);


    public static bool ToBoolean(Result? result) => result?.Succeeded is true;
    public static implicit operator bool(Result? result) => ToBoolean(result);

    public static Result FromBoolean(bool success) => new(success ? ResultStatus.Success : ResultStatus.Failure);
    public static implicit operator Result(bool success) => FromBoolean(success);
}

/// <summary>
///     Represents a strongly-typed result of an operation.
/// </summary>
/// <typeparam name="T">The type of the result value.</typeparam>
public record Result<T>(ResultStatus Status, T? TypedValue, Exception? Error = null)
    : Result(Status, TypedValue, Error)
{
    /// <summary>
    ///     Gets the strongly-typed value of the result.
    /// </summary>
    public new T? Value => TypedValue;

#pragma warning disable CA1024

    [return: NotNull]
    public new T GetValueOrThrow()
        => Succeeded && Value is not null
            ? Value
            : throw Error ?? new UnknownResultException();
}

/// <summary>
///     Represents a successful operation result.
/// </summary>
public record SuccessResult(object? Value = null)
    : Result(ResultStatus.Success, Value);

/// <summary>
///     Represents a strongly-typed successful operation result.
/// </summary>
/// <typeparam name="T">The type of the result value.</typeparam>
public record SuccessResult<T>(T Value)
    : Result<T>(ResultStatus.Success, Value);

/// <summary>
///     Represents a failed operation result.
/// </summary>
public record FailureResult : Result
{
    public FailureResult(Exception error, object? value = null)
        : base(ResultStatus.Failure, value, error)
    {
    }

    public FailureResult(string errorMessage, object? value = null)
        : this(new ResultException(errorMessage), value)
    {
    }
}

/// <summary>
///     Represents a strongly-typed failed operation result.
/// </summary>
/// <typeparam name="T">The type of the result value.</typeparam>
public record FailureResult<T>(Exception Error, T? TypedValue = default)
    : Result<T>(ResultStatus.Failure, TypedValue, Error)
{
    public FailureResult(string errorMessage, T? value = default)
        : this(new ResultException(errorMessage), value)
    {
    }
}
