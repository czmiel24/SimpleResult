namespace SimpleResult.Examples.Errors
{
    public class EmptyParameterError : Error
    {
        public EmptyParameterError(string parameterName) 
            : base($"The parameter: {parameterName} can't be empty.")
        {
        }
    }
}