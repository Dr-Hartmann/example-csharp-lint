using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RoslynRulesTest.Assets.Game.ManualFix;

// Эти примеры требуют изменения API, контракта или архитектуры.
public sealed class ResourceOwner
{
    private readonly MemoryStream _stream = new(); // CA1001: класс владеет IDisposable, но не реализует IDisposable.
}

public sealed class GenericCache<T>
{
    public static int Count { get; set; } // CA1000 / MA0018: статический член обобщённого типа.
}

public sealed class ComparableScore : IComparable
{
    public int CompareTo(object? other) => 0; // CA1036: нет согласованных Equals / операторов сравнения.
}

public sealed class BadAttribute : Attribute
{
    public BadAttribute(string value) { }
    // CA1018: нет AttributeUsage; CA1019: аргумент атрибута не сохранён в читаемом свойстве.
}

public sealed class CancellationSample
{
    public Task ExecuteAsync(CancellationToken token, int count) // CA1068: CancellationToken не последний.
        => Task.CompletedTask;

    public async Task<string> ReadAsync()
    {
        await Task.Delay(1); // MA0004: ConfigureAwait(false) не указан.
        return "done";
    }

    public Task<string> ReturnNullAsync() => null!; // MA0022

    public string Normalize(string value) => value.ToLower(); // CA1308: culture-sensitive normalization.

    public void Parse(string value)
    {
        _ = int.Parse(value); // MA0011 / CA1305: нет IFormatProvider.
        _ = value.StartsWith("x"); // MA0001 / CA1307: нет StringComparison.
    }
}

public sealed class CollectionSample
{
    public int GetCount(List<int> values) => values.Count(); // CA1829 / MA0031
    public bool HasItems(List<int> values) => values.Count() > 0; // CA1827
    public int[] Empty() => new int[0]; // CA1825 / MA0005
}

public sealed class RegexSample
{
    public bool IsMatch(string value) => System.Text.RegularExpressions.Regex.IsMatch(value, "(a)"); // MA0009 / MA0023
}

public sealed class TodoSample
{
    public void DoWork()
    {
        // TODO: implement this later.
        throw new NotImplementedException(); // MA0025 / MA0026
    }
}

public sealed class ExceptionSample
{
    public void ReThrow()
    {
        try
        {
            throw new InvalidOperationException();
        }
        catch (Exception ex)
        {
            throw ex; // CA2200
        }
    }

    public void ThrowReserved() => throw new SystemException(); // MA0012 / CA2201
}
