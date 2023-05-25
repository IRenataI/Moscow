using TMPro;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    public int LoseTarget = 5;
    public WinCondition WinCondition;
    public TextMeshProUGUI Counter;
    private QuestSystem __questSystem;
    private void Awake()
    {
        Counter.text = " " +  WinCondition.GetHittedTargetsNumber;
        __questSystem = FindObjectOfType<QuestSystem>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (WinCondition.GetHittedTargetsNumber < -LoseTarget)
        {
            __questSystem.GetCurrentQuest().InterruptQuest();
        }
        GuitarTarget __collided = collision.gameObject.GetComponent<GuitarTarget>();
        if (__collided && !__collided.IsDestroyed && !__collided.IsDeactivated)
        {
            __collided.IsDeactivated = true;
            WinCondition.DeacreaseHittedTargets();
            Counter.text = " " + WinCondition.GetHittedTargetsNumber;
            //Debug.Log("Destroyed");
        }
    }
}
