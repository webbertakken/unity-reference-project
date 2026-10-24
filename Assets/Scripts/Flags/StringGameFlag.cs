using UnityEngine;

namespace Flags
{
  [CreateAssetMenu(menuName = "Flag (string)", order = 52)]
  public class StringGameFlag : GameFlag<string>
  {
    public void Append(string value) {
      Value += value;
      SendChanged();
    }
  }
}
