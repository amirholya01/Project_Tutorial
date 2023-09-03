namespace Project.Core.Generator;

public class StringGenerator
{
    public static string CodeGenerator()
    {
        return Guid.NewGuid().ToString().Replace("-", "");
    }
}