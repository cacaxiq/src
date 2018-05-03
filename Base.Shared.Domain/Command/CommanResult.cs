namespace Base.Shared.Domain.Command
{
    public class CommanResult : ICommandResult
    {
        public CommanResult() { }

        public CommanResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
