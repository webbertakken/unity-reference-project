using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quests
{
  [CreateAssetMenu(menuName = "Quest", order = 51)]
  public class Quest : ScriptableObject
  {
    [FormerlySerializedAs("_name")]
    [SerializeField] string _displayName;
    [SerializeField] string _description;
    [SerializeField] Sprite _sprite;

    [Tooltip("Designer/programmer notes")]
    [SerializeField] string _internalNote;

    public List<Step> Steps;

    public string Name => _displayName;
    public string Description => _description;
    public Sprite Sprite => _sprite;
  }

  [Serializable]
  public class Step
  {
    [SerializeField] string _instructions;
    public string Instructions => _instructions;

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

    public override string ToString() => _type.ToString();
  }
}
