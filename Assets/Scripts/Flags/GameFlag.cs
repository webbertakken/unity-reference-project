using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Flags
{
  public abstract class GameFlag : ScriptableObject
  {
    public event Action Changed;

    protected void SendChanged() {
      Debug.LogWarning($"Value for \"{name}\" was updated.");
      Changed?.Invoke();
    }
  }

  public abstract class GameFlag<T> : GameFlag
  {
    public T RequiredValue;
    public T Value { get; protected set; }
    void OnEnable() => Value = default;
    void OnDisable() => Value = default;

    public void Set(T value) {
      Value = value;
      SendChanged();
    }
  }
}
