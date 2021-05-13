using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace GameEvents
{
  public class GameEventListener : MonoBehaviour
  {
    [Header("Source triggers")]
    [SerializeField] GameEvent _gameEventToListenFor;

    [Header("Target triggers")]
    [SerializeField] UnityEvent _unityEventToTrigger;

    void Awake() => _gameEventToListenFor.Register(this);
    void OnDisable() => _gameEventToListenFor.Deregister(this);
    public void RaiseEvent() => _unityEventToTrigger.Invoke();
  }
}
