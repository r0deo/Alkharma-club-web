namespace AlKarmahClub.Api.Common;

public sealed record SystemStatusResponse(string Service, string Status)
{
    public override string ToString()
    {
        return $"Service: {Service}, Status: {Status}";
    }
}
