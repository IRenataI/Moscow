using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Quest : MonoBehaviour, QuestInterface
{
    private QuestSystem __questSystem;
    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        __questSystem = FindAnyObjectByType<QuestSystem>();
    }
    public void StartQuest()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        __questSystem.StartQuest(GetComponent<QuestInterface>());
    }
    private void OnTriggerExit(Collider other)
    {
        __questSystem.EndQuest(GetComponent<QuestInterface>());
    }
}
