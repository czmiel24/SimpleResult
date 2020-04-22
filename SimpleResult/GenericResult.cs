using System.Collections.Generic;

namespace SimpleResult
{
    public class Result<T> : Result
    {
        public T Value { get; private set; }
        public Result(bool isSuccess, T value) : base(isSuccess)
        {
            Value = value;
        }
        public Result(Error error, T value) : base(error)
        {
            Value = value;
        }

        public Result(List<Error> errors, T value) : base(errors)
        {
            Value = value;
        }
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value);
        }

        public static Result<T> Failure(T value)
        {
            return new Result<T>(false, value);
        }

        public static Result<T> Failure(Error error, T value)
        {
            return new Result<T>(error, value);
        }

        public static Result<T> Failure(List<Error> errors, T value)
        {
            return new Result<T>(errors, value);
        }
    }
}