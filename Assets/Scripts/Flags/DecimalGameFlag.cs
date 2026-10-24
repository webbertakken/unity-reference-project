using UnityEngine;

namespace Flags
{
  [CreateAssetMenu(menuName = "Flag (decimal)", order = 52)]
  public class DecimalGameFlag : GameFlag<decimal>
  {
    public void Add(decimal value) {
      Value += value;
      SendChanged();
    }

    public void Subtract(decimal value) {
      Value -= value;
      SendChanged();
    }
  }
}
