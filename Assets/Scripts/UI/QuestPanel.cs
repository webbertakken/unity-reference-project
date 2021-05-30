using System.Linq;
using System.Text;
using Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class QuestPanel : ToggleablePanel
  {
    [SerializeField] Quest _selectedQuest;
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _descriptionText;
    [SerializeField] TMP_Text _currentObjective;
    [SerializeField] Image _iconImage;

    Step _selectedStep => _selectedQuest.CurrentStep;

    [ContextMenu("Bind")]
    public void Bind() {
      // Quest
      _nameText.SetText(_selectedQuest.DisplayName);
      _descriptionText.SetText(_selectedQuest.Description);
      _iconImage.sprite = _selectedQuest.Sprite;

      // Step
      DisplayStepInstructionsAndObjectives();
    }

    void DisplayStepInstructionsAndObjectives() {
      StringBuilder builder = new StringBuilder();

      if (_selectedStep != null) {
        builder.AppendLine(_selectedStep.Instructions);
        foreach (var objective in _selectedStep.Objectives) {
          string rgb = objective.IsCompleted ? "green" : "red";
          builder.AppendLine($"<color={rgb}>{objective}</color>");
        }
      }

      _currentObjective.SetText(builder.ToString());
    }

    public void SelectQuest(Quest quest) {
      Debug.LogWarning($"Quest set to {quest.DisplayName}");
      if (_selectedQuest != null) {
        _selectedQuest.Changed -= DisplayStepInstructionsAndObjectives;
      }

      _selectedQuest = quest;
      Bind();
      Show();

      _selectedQuest.Changed += DisplayStepInstructionsAndObjectives;
    }
  }
}
