using UnityEngine;

namespace Flags
{
  public class GameFlagColliderTrigger : MonoBehaviour
  {
    [Header("Source trigger")]
    [SerializeField] bool _triggerOnce = true;

    [Header("Target triggers")]
    [SerializeField] GameFlag _gameFlagToSet;

    [Header("How to modify flag")]
    [SerializeField] bool _setToBoolean = true;
    [SerializeField] int _modifyBy = 1;
    [SerializeField] float _secondsDelay = 0f;

    bool _hasTriggered = false;

    bool ShouldTrigger() {
      if (_triggerOnce) return !_hasTriggered;

      return true;
    }

    void OnTriggerEnter(Collider other) {
      var player = other.GetComponent<ThirdPersonMover>();
      if (player != null && ShouldTrigger()) {
        _hasTriggered = true;
        Invoke(nameof(Trigger), _secondsDelay);
      }
    }

    void Trigger() {
      Debug.LogWarning("setting flag");

      switch (_gameFlagToSet) {
        case BooleanGameFlag booleanGameFlag:
          booleanGameFlag.Set(_setToBoolean);
          break;
        case IntegerGameFlag countGameFlag:
          countGameFlag.Add(_modifyBy);
          break;
        default:
          Debug.LogWarning($"Unable to update \"{_gameFlagToSet}\" by ColliderTrigger.");
          break;
      }
    }
  }
}
