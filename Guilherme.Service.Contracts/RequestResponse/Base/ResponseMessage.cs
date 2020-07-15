namespace Guilherme.Service.Contracts.RequestResponse.Base
{
    public class ResponseMessage<T> where T : class
    {
        public T Data { get; set; }

        public int StatusCode { get; set; }

        public Error Error { get; set; }
    }

    public class Error
    {
        public Error(string message, string stackTrace)
        {
            Message = message;
            StackTrace = stackTrace;
        }

        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}