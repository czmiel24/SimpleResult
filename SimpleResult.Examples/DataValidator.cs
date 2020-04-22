using SimpleResult.Examples.Errors;

namespace SimpleResult.Examples
{
    public class DataValidator
    {
        public Result Validate(string parameter)
        {
            if(string.IsNullOrEmpty(parameter))
                return Result.Failure(new EmptyParameterError("parameter"));
            
            if(parameter == "!")
                return Result.Failure(new InvalidParameterError("parameter", parameter));

            return Result.Success();
        }
    }
}