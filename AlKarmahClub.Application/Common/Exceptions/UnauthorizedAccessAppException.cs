namespace AlKarmahClub.Application.Common.Exceptions;

public class UnauthorizedAccessAppException : Exception
{
    public UnauthorizedAccessAppException()
        : base("Authentication is required to access this resource.")
    {
    }

    public UnauthorizedAccessAppException(string message)
        : base(message)
    {
    }
}
