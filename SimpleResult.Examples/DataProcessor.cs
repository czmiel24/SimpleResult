namespace SimpleResult.Examples
{
    public class DataProcessor
    {
        public Result<string> Process(string parameter)
        {
            return Result<string>.Success(parameter + parameter);
        }
    }
}