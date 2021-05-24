using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flag (bool)", order = 52)]
public class GameFlag : ScriptableObject
{
  public bool Value;

  void OnEnable() => Value = default;
}
