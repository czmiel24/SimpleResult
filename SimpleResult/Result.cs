using System;
using System.Collections.Generic;

namespace SimpleResult
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public List<Error> Errors { get; }

        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
            Errors = new List<Error>();
        }

        public Result(Error error) : this(false) 
        {
            if(error == null)
                throw new ArgumentNullException(nameof(error));

            Errors.Add(error);
        }

        public Result(List<Error> errors) : this(false)
        {
            if(errors == null)
                throw new ArgumentNullException(nameof(errors));

            Errors = errors;   
        }

        public void AddError(Error error)
        {
            if(error == null)
                throw new ArgumentNullException(nameof(error));

            Errors.Add(error);
            IsSuccess = false;
        }

        public static Result Success()
        {
            return new Result(true);
        }

        public static Result Failure()
        {
            return new Result(false);
        }

        public static Result Failure(Error error)
        {
            return new Result(error);
        }

        public static Result Failure(List<Error> errors)
        {
            return new Result(errors);
        }
    }
}
