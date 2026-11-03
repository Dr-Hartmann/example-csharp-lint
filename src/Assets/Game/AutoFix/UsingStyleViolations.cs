using System.IO;

namespace RoslynRulesTest.Assets.Game.AutoFix;

internal sealed class UsingStyleViolations
{
    public void WriteByte()
    {
        using (var stream = new MemoryStream())
        {
            stream.WriteByte(1);
        }
    }
}
