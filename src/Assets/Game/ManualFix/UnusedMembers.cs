namespace RoslynRulesTest.Assets.Game.ManualFix;

// IDE0051 / IDE0052: удаление закрытых членов безопасно только после проверки usages.
public sealed class UnusedMembers
{
    private int _cachedValue = 42;

    private event EventHandler? _unusedEvent;

    private void NeverCalled()
    {
    }
}
