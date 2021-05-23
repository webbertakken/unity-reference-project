using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameEvents
{
  [CreateAssetMenu(menuName = "Game Event", order = 50)]
  public class GameEvent : ScriptableObject
  {
    static HashSet<GameEvent> _listenedEvents = new HashSet<GameEvent>();

    HashSet<GameEventListener> _gameEventListeners = new HashSet<GameEventListener>();

    public void Register(GameEventListener gameEventListener) {
      _gameEventListeners.Add(gameEventListener);
      _listenedEvents.Add(this);
    }

    public void Deregister(GameEventListener gameEventListener) {
      _gameEventListeners.Remove(gameEventListener);
      if (_gameEventListeners.Count <= 0) {
        _listenedEvents.Remove(this);
      }
    }

    [ContextMenu("Invoke")]
    public void Invoke() {
      foreach (var gameEventListener in _gameEventListeners) {
        gameEventListener.RaiseEvent();
      }
    }

    public static void RaiseEvent(string eventName) {
      var count = 0;
      foreach (var listenedEvent in _listenedEvents.Where(listenedEvent => listenedEvent.name == eventName)) {
        count++;
        listenedEvent.Invoke();
      }
      Debug.Log($"{eventName} triggered. {count.ToString()} listeners.");
    }
  }
}
