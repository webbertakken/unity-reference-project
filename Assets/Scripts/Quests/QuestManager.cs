using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Quests;
using UI;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
  List<Quest> _activeQuests = new List<Quest>();

  [SerializeField] QuestPanel _questPanel;
  [SerializeField] List<Quest> _allQuests;

  public static QuestManager Instance { get; private set; }

  void Awake() => Instance = this;

  public void AddQuest(Quest quest) {
    _activeQuests.Add(quest);
    _questPanel.SelectQuest(quest);
  }

  public void AddQuestByName(string questName) {
    var quest = _allQuests.FirstOrDefault(t => t.name == questName);

    if (quest != null) {
      AddQuest(quest);
    } else {
      Debug.LogWarning($"Could not add quest by name {questName}");
    }
  }
}
