using UnityEngine;

namespace RoslynRulesTest.Assets.Game.ManualFix;

public sealed class UnityNullCoalescing : MonoBehaviour
{
    public GameObject? GetOrFallback(GameObject? candidate, GameObject fallback)
        => candidate ?? fallback; // UNT0007: Unity-specific null semantics; review the resulting expression.
}
