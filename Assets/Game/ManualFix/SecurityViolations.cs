using System;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.Http;

namespace RoslynRulesTest.Assets.Game.ManualFix;

// Изолированные учебные примеры небезопасных API. Не использовать в приложениях.
public static class SecurityViolations
{
    public static byte[] WeakHash(string value)
    {
        using var algorithm = MD5.Create(); // CA5351
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
    }

    public static byte[] WeakRandom(int length)
    {
        var random = new Random(); // CA5394 отключён в корневом .editorconfig.
        var bytes = new byte[length];
        random.NextBytes(bytes);
        return bytes;
    }

    public static HttpClient CreateWithoutCertificateValidation()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true, // CA5359
        };
        return new HttpClient(handler);
    }

    public static byte[] HardCodedKey()
    {
        byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 }; // CA5390
        return key;
    }
}

// MA0039: собственный callback проверки сертификата требует ручного выбора доверенной политики.
public static class CertificatePolicyViolation
{
    public static bool AcceptAnyCertificate(object? sender, System.Security.Cryptography.X509Certificates.X509Certificate? certificate,
        System.Security.Cryptography.X509Certificates.X509Chain? chain, System.Net.Security.SslPolicyErrors errors)
        => true;
}
