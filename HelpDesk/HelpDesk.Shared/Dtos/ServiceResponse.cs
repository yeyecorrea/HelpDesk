namespace HelpDesk.Shared.Dtos
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static ServiceResponse Ok()
        {
            return new ServiceResponse { Success = true, Errors = Enumerable.Empty<string>() };
        }

        public static ServiceResponse Fail(IEnumerable<string> errors)
        {
            return new ServiceResponse { Success = false, Errors = errors };
        }
    }
}
