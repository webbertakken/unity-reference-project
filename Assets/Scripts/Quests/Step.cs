using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
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
}
