using UnityEngine;

namespace Flags
{
  [CreateAssetMenu(menuName = "Flag (count)", order = 52)]
  public class CountGameFlag : GameFlag<int>
  {
    public void Modify(int value) {
      Value += value;
      SendChanged();
    }
  }
}
