namespace Project.Core.Utils;

public class Valid
{
    public static string EmailValid(string email)
    {
        return email.Trim().ToLower();
    }
}