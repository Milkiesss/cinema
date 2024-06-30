using System.Text;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace cinema.Application.Services;

public class CryptograaphyService
{
    public string HashPassword(string password)
    {
        var salt = GenerateSalt();
        var hash = GenerateHash(password, salt);

        return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
    }

    public bool VerifyPassword(string password, string hashpassword)
    {
        var parts = hashpassword.Split(':');
        var salt = Convert.FromBase64String(parts[0]);
        var hash = Convert.FromBase64String(parts[1]);

        var testhasch = GenerateHash(password, salt);

        return AreHashesEqual(hash, testhasch);
    }

    public bool AreHashesEqual(byte[] hash1, byte[] hash2)
    {
        if (hash1.Length != hash2.Length)
            return false;

        return hash1.SequenceEqual(hash2);
    }

    public byte[] GenerateHash(string password, byte[] salt)
    {
        var hashGenerate = new Pkcs5S2ParametersGenerator();
        hashGenerate.Init(Encoding.UTF8.GetBytes(password), salt, 100);
        var key = (KeyParameter)hashGenerate.GenerateDerivedMacParameters(64);
        return key.GetKey();
    }

    public byte[] GenerateSalt()
    {
        var salt = new byte[16];
        var rnd = new SecureRandom();
        rnd.NextBytes(salt);
        return salt;
    }
}