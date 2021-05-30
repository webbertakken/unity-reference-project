using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
  [CreateAssetMenu(menuName = "Quest", order = 51)]
  public class Quest : ScriptableObject
  {
    public event Action Changed;

    [SerializeField] string _displayName;
    [SerializeField] string _description;
    [SerializeField] Sprite _sprite;

    [Tooltip("Designer/programmer notes")]
    [SerializeField] string _internalNote;

    int _currentStepIndex = 0;

    public List<Step> Steps;

    public string DisplayName => _displayName;
    public string Description => _description;
    public Sprite Sprite => _sprite;

    public Step CurrentStep => Steps[_currentStepIndex];

    void OnEnable() {
      _currentStepIndex = 0;
      foreach (var step in Steps) {
        foreach (var objective in step.Objectives) {
          if (objective.gameFlag != null) {
            objective.gameFlag.Changed += OnObjectiveChanged;
          }
        }
      }
    }

    void OnObjectiveChanged() {
      TryProgress();
      Changed?.Invoke();
    }

    public void TryProgress() {
      var currentStep = GetCurrentStep();
      if (currentStep.HasAllObjectivesCompleted()) {
        _currentStepIndex++;
        Changed?.Invoke();
      }
    }

    Step GetCurrentStep() => Steps[_currentStepIndex];
  }
}
