using UnityEngine;

namespace Flags
{
  [CreateAssetMenu(menuName = "Flag (integer)", order = 52)]
  public class IntegerGameFlag : GameFlag<int>
  {
    public void Add(int value) {
      Value += value;
      SendChanged();
    }

    public void Subtract(int value) {
      Value -= value;
      SendChanged();
    }
  }
}
