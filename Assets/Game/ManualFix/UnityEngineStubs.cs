// Минимальные заглушки, чтобы проект собирался вне Unity Editor.
// Анализаторы Unity распознают типы по пространству имён и иерархии UnityEngine.Object.
namespace UnityEngine;

public class Object
{
    public static bool operator ==(Object? left, Object? right)
        => ReferenceEquals(left, right);

    public static bool operator !=(Object? left, Object? right)
        => !ReferenceEquals(left, right);

    public override bool Equals(object? obj) => ReferenceEquals(this, obj);
    public override int GetHashCode() => base.GetHashCode();
}

public class Component : Object
{
    public string name { get; set; } = string.Empty;
}

public class GameObject : Object
{
    public string name { get; set; } = string.Empty;
}

public class MonoBehaviour : Component
{
}
