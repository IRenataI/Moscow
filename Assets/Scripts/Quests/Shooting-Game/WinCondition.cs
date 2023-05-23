using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int ObjectsToHit;
    public TargetsAbstract[] Targets;
    public int GetHittedTargetsNumber { get { return __hittedTargets; } }
    private int __hittedTargets = 0;
    private Quest __quest;
    private void Awake()
    {
        __quest = GetComponent<Quest>();
        for (int i = 0; i < Targets.Length; i++)
        {
            Targets[i].SetWinCodition(this);
        }
    }
    public void IncreaseHittedTargets()
    {
        __hittedTargets++;
        if (__hittedTargets >= ObjectsToHit)
        {
            __quest.EndQuest();
            Debug.Log("All targets down");
        }
        Debug.Log(gameObject.name +  " __hittedTargets " + __hittedTargets + " ObjectToHit " + ObjectsToHit);
    }
    public void DeacreaseHittedTargets()
    {
        __hittedTargets--;
    }
}
//public UnityEvent AfterHittedAllTargets;
//AfterHittedAllTargets?.Invoke();