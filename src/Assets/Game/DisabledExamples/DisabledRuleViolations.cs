using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoslynRulesTest.Assets.Game.DisabledExamples;

// Намеренные примеры для диагностик, у которых эффективная строгость none.
// При текущем .editorconfig эти диагностики не должны появляться.
public static class DisabledRuleViolations
{
    public static void LocalizedLiteral()
        => Console.WriteLine("hard-coded text"); // CA1303 отключён.

    public static byte[] WeakRandom(int length)
    {
        var random = new Random(); // CA5394 отключён.
        var bytes = new byte[length];
        random.NextBytes(bytes);
        return bytes;
    }

    public static void BlockingWait(Task task)
        => task.Wait(); // MA0045 отключён.

    public static bool StringEquality(string left, string right)
        => left == right; // MA0006 отключён.

    public static void RedundantElse(bool condition)
    {
        if (condition)
        {
            return;
        }
        else
        {
            Console.WriteLine("else branch"); // MA0071 отключён.
        }
    }

    public static bool ConstantCondition(string value)
    {
        if (value is null) // CA1508: для non-nullable string условие заведомо ложно.
        {
            return false;
        }
        return true;
    }
}

// CA1710 отключён: для типа, наследующего коллекцию, имя не использует ожидаемый суффикс.
public sealed class ItemList : List<string>
{
}
