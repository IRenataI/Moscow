using UnityEngine;

public class Deactivator : MonoBehaviour
{
    public Quest GuitarQuest;
    public int LoseTarget = 10;
    public WinCondition WinCondition;
    private GuitarUICounter GuitarCounter;
    private void Awake()
    {
        GuitarCounter = FindObjectOfType<GuitarUICounter>();
        GuitarCounter.ChangeText(" " + WinCondition.GetHittedTargetsNumber);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (WinCondition.GetHittedTargetsNumber < -LoseTarget)
        {
            GuitarQuest.InterruptQuest();
        }
        GuitarTarget __collided = collision.gameObject.GetComponent<GuitarTarget>();
        if (__collided && !__collided.IsDestroyed && !__collided.IsDeactivated)
        {
            __collided.IsDeactivated = true;
            WinCondition.DeacreaseHittedTargets();
            GuitarCounter.ChangeText(" " + WinCondition.GetHittedTargetsNumber);
            //Debug.Log("Destroyed");
        }
    }
}
