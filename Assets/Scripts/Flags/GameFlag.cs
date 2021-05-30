using UnityEngine;

namespace Flags
{
  [CreateAssetMenu(menuName = "Flag (bool)", order = 52)]
  public class GameFlag : ScriptableObject
  {
    public bool Value;

    void OnEnable() => Value = default;
  }
}
