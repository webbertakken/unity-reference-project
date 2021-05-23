using Quests;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class QuestGiver : MonoBehaviour
{
  [SerializeField] Quest _questToGive;

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      QuestManager.Instance.AddQuest(_questToGive);
    }
  }
}
