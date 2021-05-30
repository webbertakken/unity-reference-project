using System;
using UnityEngine;

namespace Flags
{
  [CreateAssetMenu(menuName = "Flag (bool)", order = 52)]
  public class GameFlag : ScriptableObject
  {
    public event Action Changed;
    public bool Value { get; private set; }

    void OnEnable() => Value = default;
    void OnDisable() => Value = default;

    public void Set(bool value) {
      Debug.LogWarning($"Setting new value for {name}");
      Value = value;
      Changed?.Invoke();
    }
  }
}
