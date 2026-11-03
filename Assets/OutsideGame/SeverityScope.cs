using System;

namespace RoslynRulesTest.Assets.OutsideGame;

// Для файлов вне Assets/Game CS0067 и CS0618 заданы как none.
public sealed class SeverityScope
{
    public event EventHandler? UnusedEvent; // CS0067 отключён здесь.

    [Obsolete("Use NewApi instead.")]
    public static void OldApi() { }

    public static void CallOldApi()
    {
        OldApi(); // CS0618 отключён здесь.
    }
}
