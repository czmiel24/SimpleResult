namespace SimpleResult
{
    public class Error
    {
        public Error()
        {
        }
        public string Message { get; }

        public Error(string message)
        {
            this.Message = message;
        }
    }
}