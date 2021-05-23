using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DialogGiver : MonoBehaviour
{
  [SerializeField] TextAsset _dialog;

  void OnTriggerEnter(Collider other) {
    var player = other.GetComponent<ThirdPersonMover>();
    if (player != null) {
      transform.LookAt(player.transform);
      FindObjectOfType<DialogController>().OpenDialog().StartDialog(_dialog);
    }
  }
}
