using System;
using System.Collections.Generic;
using Flags;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quests
{
  [CreateAssetMenu(menuName = "Quest", order = 51)]
  public class Quest : ScriptableObject
  {
    public event Action Progressed;

    [SerializeField] string _displayName;
    [SerializeField] string _description;
    [SerializeField] Sprite _sprite;

    [Tooltip("Designer/programmer notes")]
    [SerializeField] string _internalNote;

    int _currentStepIndex;

    public List<Step> Steps;

    public string DisplayName => _displayName;
    public string Description => _description;
    public Sprite Sprite => _sprite;

    public Step CurrentStep => Steps[_currentStepIndex];

    public void TryProgress() {
      var currentStep = GetCurrentStep();
      if (currentStep.HasAllObjectivesCompleted()) {
        _currentStepIndex++;
        Progressed?.Invoke();
      }
    }

    Step GetCurrentStep() => Steps[_currentStepIndex];
  }

  [Serializable]
  public class Step
  {
    [SerializeField] string _instructions;
    public string Instructions => _instructions;

    public List<Objective> Objectives;

    public bool HasAllObjectivesCompleted() {
      return Objectives.TrueForAll(objective => objective.IsCompleted);
    }
  }

  [Serializable]
  public class Objective
  {
    [SerializeField] ObjectiveType _type;
    [SerializeField] GameFlag _gameFlag;

    public enum ObjectiveType
    {
      Flag,
      Item,
      Kill,
    }

    public bool IsCompleted {
      get {
        switch (_type) {
          case ObjectiveType.Flag:
            return _gameFlag.Value;
          default: {
            Debug.LogWarning($"IsCompleted: Unhandled type {_type}");
            return false;
          }
        }
      }
    }

    public override string ToString() {
      switch (_type) {
        case ObjectiveType.Flag:
          return _gameFlag.name;
        default: {
          return _type.ToString();
        }
      }
    }
  }
}
