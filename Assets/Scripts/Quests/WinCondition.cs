using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private int ObjectsToHit;
    [SerializeField] private TargetsAbstract[] Targets;
    private QuestPhotoObject questPhotoObject;

    private int __hittedTargets = 0;
    private Quest __quest;
    public int GetHittedTargetsNumber => __hittedTargets;
    public int GetObjectsToHit => ObjectsToHit;
    private void Awake()
    {
        questPhotoObject = GetComponent<QuestPhotoObject>();

        if (questPhotoObject && !questPhotoObject.AllowQuest)
        {
            //Debug.LogWarning(gameObject.name + ": increase objects to hit");
            ObjectsToHit++;
        }  
        __quest = GetComponent<Quest>();
        for (int i = 0; i < Targets.Length; i++)
        {
            Targets[i].SetWinCodition(this);
        }
    }
    public void IncreaseHittedTargets()
    {
        __hittedTargets++;

        if (ObjectsToHit - __hittedTargets == 1)
        {
            questPhotoObject?.Allow();
        }

        if (__hittedTargets >= ObjectsToHit)
        {
            __quest?.EndQuest();
            //Debug.Log("All targets down");  
        }
        Debug.Log(gameObject.name +  " __hittedTargets " + __hittedTargets + " ObjectToHit " + ObjectsToHit);
    }
    public void DeacreaseHittedTargets()
    {
        __hittedTargets--;
    }
    public void ResetHittedTargets()
    {
        __hittedTargets = 0;
        for (int i = 0; i < Targets.Length; i++)
        {
            Targets[i].ResetDestroyedCondition();
        }
        //Debug.Log("resetHittedTargets");
    }
}