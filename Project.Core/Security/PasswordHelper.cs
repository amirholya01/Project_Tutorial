using System.Security.Cryptography;
using System.Text;

namespace Project.Core.Security;

public class PasswordHelper
{
    public static string EncodePassword(string pass)
    {
        Byte[] originalBytes;
        Byte[] encodedBytes;
        MD5 md5 = new MD5CryptoServiceProvider();
        originalBytes = ASCIIEncoding.Default.GetBytes(pass);
        encodedBytes = md5.ComputeHash(originalBytes);
        return BitConverter.ToString(encodedBytes);

    }
}