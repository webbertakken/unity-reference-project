using System;
using Flags;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quests
{
  [Serializable]
  public class Objective
  {
    [SerializeField] ObjectiveType _type;
    [SerializeField] GameFlag _gameFlag;

    public enum ObjectiveType
    {
      GameFlag,
      Item,
      Kill,
    }

    public GameFlag gameFlag => _gameFlag;

    public bool IsCompleted {
      get {
        switch (_type) {
          case ObjectiveType.GameFlag: {
            switch (_gameFlag) {
              case BooleanGameFlag booleanGameFlag:
                return booleanGameFlag.Value;
              case CountGameFlag countGameFlag:
                return countGameFlag.Value == countGameFlag.RequiredValue;
              default:
                Debug.LogWarning($"IsCompleted: Unhandled type {_type}");
                return false;
            }
          }
        }

        return false;
      }
    }

    public override string ToString() {
      switch (_type) {
        case ObjectiveType.GameFlag: {
          switch (_gameFlag) {
            case BooleanGameFlag booleanGameFlag:
              return booleanGameFlag.name;
            case CountGameFlag countGameFlag:
              return $"{countGameFlag.name} ({countGameFlag.Value}/{countGameFlag.RequiredValue})";
            default:
              Debug.LogWarning($"ToString: Unhandled GameFlag type ${_gameFlag}");
              return _gameFlag.ToString();
          }
        }
        default: {
          Debug.LogWarning($"ToString: Unhandled type ${_type}");
          return _type.ToString();
        }
      }
    }
  }
}
