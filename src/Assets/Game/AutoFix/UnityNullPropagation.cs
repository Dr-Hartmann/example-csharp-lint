using UnityEngine;

namespace RoslynRulesTest.Assets.Game.AutoFix;

public sealed class UnityNullPropagation : MonoBehaviour
{
    public string? ReadName(GameObject? candidate)
        => candidate?.name; // UNT0008: analyzer has a code fix.
}
