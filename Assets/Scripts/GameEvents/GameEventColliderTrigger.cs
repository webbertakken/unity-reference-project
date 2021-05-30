using System.Collections;
using System.Collections.Generic;
using GameEvents;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider))]
public class GameEventColliderTrigger: MonoBehaviour
{
  [Header("Target triggers")]
  [SerializeField] GameEvent _gameEventToTrigger;
  [SerializeField] float _secondsDelay = 0f;

  void OnTriggerEnter(Collider other) {
    var player = other.GetComponent<ThirdPersonMover>();
    if (player != null) {
      Invoke(nameof(Trigger), _secondsDelay);
    }
  }

  void Trigger() {
    _gameEventToTrigger.Invoke();
  }
}
