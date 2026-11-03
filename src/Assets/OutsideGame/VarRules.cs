namespace RoslynRulesTest.Assets.OutsideGame;

// Вне Assets/Game параметры csharp_style_var_* из игрового раздела не действуют.
internal sealed class VarRules
{
    public void Demonstrate()
    {
        var text = "prefer explicit type here";
    }
}
