namespace AlKarmahClub.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures occurred.")
    {
        Errors = [];
    }

    public ValidationException(string message)
        : base(message)
    {
        Errors = [message];
    }

    public ValidationException(IEnumerable<string> errors)
        : base("One or more validation failures occurred.")
    {
        Errors = errors.ToArray();
    }

    public IReadOnlyCollection<string> Errors { get; }
}
