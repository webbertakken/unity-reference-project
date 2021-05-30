using System;
using UnityEngine;

namespace Flags
{
  public class GameFlagColliderTrigger : MonoBehaviour
  {
    [Header("Target triggers")]
    [SerializeField] GameFlag _gameFlagToSet;
    [SerializeField] bool _setToValue = true;
    [SerializeField] float _secondsDelay = 0f;

    void OnTriggerEnter(Collider other) {
      var player = other.GetComponent<ThirdPersonMover>();
      if (player != null) {
        Invoke(nameof(Trigger), _secondsDelay);
      }
    }

    void Trigger() {
      Debug.LogWarning("setting flag");
      _gameFlagToSet.Set(_setToValue);
    }
  }
}
