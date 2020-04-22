namespace SimpleResult.Examples.Errors
{
    public class InvalidParameterError : Error
    {
       public InvalidParameterError(string parameterName, string parameterValue) 
           : base($"The parameter: {parameterName} has invalid value: {parameterValue}")
       {
       } 
    }
}