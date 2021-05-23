using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
  [CreateAssetMenu(menuName = "Quest", order = 51)]
  public class Quest : ScriptableObject
  {
    [SerializeField] string _name;
    [SerializeField] string _description;

    [Tooltip("Designer/programmer notes")]
    [SerializeField] string _internalNote;

    public List<Step> Steps;
  }

  [Serializable]
  public class Step
  {
    [SerializeField] string _instructions;

    public List<Objective> Objectives;
  }

  [Serializable]
  public class Objective
  {
    [SerializeField] ObjectiveType _type;
    public enum ObjectiveType
    {
      Flag,
      Item,
      Kill,
    }
  }
}
