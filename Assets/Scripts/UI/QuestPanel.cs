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

    Step _selectedStep;

    [ContextMenu("Bind")]
    public void Bind() {
      // Quest
      _nameText.SetText(_selectedQuest.Name);
      _descriptionText.SetText(_selectedQuest.Description);
      _iconImage.sprite = _selectedQuest.Sprite;

      // Step
      _selectedStep = _selectedQuest.Steps.FirstOrDefault();
      DisplayStepInstructions();
    }

    void DisplayStepInstructions() {
      StringBuilder builder = new StringBuilder();

      if (_selectedStep != null) {
        builder.AppendLine(_selectedStep.Instructions);
        foreach (var objective in _selectedStep.Objectives) {
          builder.AppendLine(objective.ToString());
        }
      }

      _currentObjective.SetText(builder.ToString());
    }

    public void SelectQuest(Quest quest) {
      _selectedQuest = quest;
      Bind();
      Show();
    }
  }
}