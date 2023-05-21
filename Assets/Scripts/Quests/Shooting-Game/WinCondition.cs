using UnityEngine;
using UnityEngine.Events;

public class WinCondition : MonoBehaviour
{
    public bool IsWon = false;
    public TargetsAbstract[] Targets;
    public UnityEvent QuestCompletionEvent;
    private int __hittedTargets = 0;
    public void IncreaseHittedTargets()
    {
        __hittedTargets++;
        if (__hittedTargets >= Targets.Length)
        {
            IsWon = true;
            QuestCompletionEvent?.Invoke();
            Debug.Log("All targets down");
        }
        Debug.Log(gameObject.name +  " __hittedTargets " + __hittedTargets + " Targets.Length " + Targets.Length);
    }
}
