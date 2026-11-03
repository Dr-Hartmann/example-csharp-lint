using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace RoslynRulesTest.Assets.Game.ManualFix;

public static class SerializationViolations
{
#pragma warning disable SYSLIB0011
    public static object? DeserializeUntrusted(Stream input)
    {
        var formatter = new BinaryFormatter();
        return formatter.Deserialize(input); // CA2300 / CA2301 / CA2302
    }
#pragma warning restore SYSLIB0011

    public static XmlReader CreateUnsafeReader(TextReader input)
    {
        var settings = new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Parse,
            XmlResolver = new XmlUrlResolver(),
        };
        return XmlReader.Create(input, settings); // CA3075 / CA3076 and related XML rules
    }
}
