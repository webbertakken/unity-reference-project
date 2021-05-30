using System.Collections;
using System.Collections.Generic;
using Flags;
using UnityEngine;

public class GameFlagColliderTrigger : MonoBehaviour
{
  [Header("Target triggers")]
  [SerializeField] GameFlag _gameFlagToSet;
  [SerializeField] bool _setToValue = true;

  void OnTriggerEnter(Collider other) {
    var player = other.GetComponent<ThirdPersonMover>();
    if (player != null) {
      Invoke(nameof(Trigger), 0f);
    }
  }

  void Trigger() {
    _gameFlagToSet.Value = _setToValue;
  }
}
