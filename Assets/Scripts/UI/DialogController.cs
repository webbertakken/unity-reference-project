using System.Linq;
using System.Text;
using GameEvents;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class DialogController : ToggleablePanel
  {
    [SerializeField] TMP_Text _storyText;
    [SerializeField] Button[] _choiceButtons;

    Story _story;

    [ContextMenu("Start Dialog")]
    public void StartDialog(TextAsset dialog) {
      Show();
      _story = new Story(dialog.text);
      RefreshView();
    }

    public new void Show() {
      base.Show();
      ThirdPersonMover.Instance.ToggleEnabled(false);
    }

    public new void Hide() {
      base.Hide();
      ThirdPersonMover.Instance.ToggleEnabled(true);
    }

    void RefreshView() {
      StringBuilder storyTestBuilder = new StringBuilder();

      while (_story.canContinue) {
        storyTestBuilder.AppendLine(_story.Continue());
        HandleTags();
      }

      _storyText.SetText(storyTestBuilder);

      for (int i = 0; i < _choiceButtons.Length; i++) {
        var button = _choiceButtons[i];
        var isActive = i < _story.currentChoices.Count;

        button.gameObject.SetActive(isActive);
        button.onClick.RemoveAllListeners();

        if (!isActive) continue;

        var choice = _story.currentChoices[i];
        button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
        button.onClick.AddListener(
          () => {
            _story.ChooseChoiceIndex(choice.index);
            RefreshView();
          }
        );
      }
    }

    void HandleTags() {
      foreach (var tag in _story.currentTags) {
        // Detect and process event tags
        string[] tagParts = tag.Split('.');
        string identifier = tagParts[0];
        string tagContent = string.Join(".", tagParts.Skip(1));

        switch (identifier) {
          case "Event":
            GameEvent.RaiseEvent(tagContent);
            continue;
          case "Quest":
            QuestManager.Instance.AddQuestByName(tagContent);
            continue;
          default:
            Debug.LogWarning($"Unhandled tag: {tag}");
            break;
        }
      }
    }
  }
}
