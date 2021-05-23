using System;
using System.Collections;
using System.Collections.Generic;
using Quests;
using UI;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
  List<Quest> _activeQuests = new List<Quest>();

  [SerializeField] QuestPanel _questPanel;

  public static QuestManager Instance { get; private set; }

  void Awake() => Instance = this;

  public void AddQuest(Quest quest) {
    _activeQuests.Add(quest);
    _questPanel.SelectQuest(quest);
  }

}
