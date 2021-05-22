using System.Collections;
using System.Collections.Generic;
using GameEvents;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class GameEventColliderTrigger: MonoBehaviour
{
  [Header("Target triggers")]
  [SerializeField] GameEvent _gameEventsToTrigger;

  void OnTriggerEnter(Collider other) {
    var player = other.GetComponent<ThirdPersonMover>();
    if (player != null) {
      _gameEventsToTrigger.Invoke();
    }
  }
}
