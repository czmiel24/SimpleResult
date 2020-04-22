using System;

namespace SimpleResult.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            DataValidator validator = new DataValidator();
            string parameter = Console.ReadLine();

            Result validationResult = validator.Validate(parameter);
            if(!validationResult.IsSuccess)
            {
                foreach (var error in validationResult.Errors)
                    System.Console.WriteLine(error.Message);
            }

            DataProcessor processor = new DataProcessor();
            Result<string> processingResult = processor.Process(parameter);
            System.Console.WriteLine(processingResult.Value);
        }
    }
}
