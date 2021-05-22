using System.Text;
using GameEvents;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class DialogController : MonoBehaviour
  {
    [SerializeField] TMP_Text _storyText;
    [SerializeField] Button[] _choiceButtons;

    Story _story;
    CanvasGroup _canvasGroup;

    void Awake() {
      _canvasGroup = GetComponent<CanvasGroup>();
      CloseDialog();
    }

    [ContextMenu("Start Dialog")]
    public void StartDialog(TextAsset dialog) {
      _story = new Story(dialog.text);
      RefreshView();
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
        string eventIdentifier = "Event.";
        if (tag.StartsWith(eventIdentifier)) {
          string eventName = tag.Remove(0, eventIdentifier.Length);
          GameEvent.RaiseEvent(eventName);
          continue;
        }

        Debug.LogWarning($"Unhandled tag: {tag}");
      }
    }

    public DialogController OpenDialog() {
      _canvasGroup.alpha = .7f;
      _canvasGroup.interactable = true;
      _canvasGroup.blocksRaycasts = true;

      return this;
    }

    public void CloseDialog() {
      _canvasGroup.alpha = 0f;
      _canvasGroup.interactable = false;
      _canvasGroup.blocksRaycasts = false;
    }
  }
}
