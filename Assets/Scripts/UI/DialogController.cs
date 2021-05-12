using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
  [SerializeField] TextAsset _dialog;
  [SerializeField] TMP_Text _storyText;
  [SerializeField] Button[] _choiceButtons;

  Story _story;

  void Awake() { }

  [ContextMenu("Start Dialog")]
  void StartDialog() {
    _story = new Story(_dialog.text);
    RefreshView();
  }

  void RefreshView() {
    StringBuilder storyTestBuilder = new StringBuilder();

    while (_story.canContinue) {
      storyTestBuilder.AppendLine(_story.Continue());
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
}
