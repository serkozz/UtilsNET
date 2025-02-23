namespace UtilsNET.Common;

public class Result<T>
{
    public T? Value { get; }
    public List<Exception> Errors { get; } = [];
    public bool IsSuccess => Errors.Count == 0;

    private Result(T value) => Value = value;
    private Result(IEnumerable<Exception> errors) => Errors.AddRange(errors);

    public static Result<T> Success(T value) => new(value);

    public static Result<T> Failure(params Exception[] errors) => new(errors);

    public static Result<T> Failure(IEnumerable<Exception> errors) => new(errors);
}
