using TMPro;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    public WinCondition __winCondition;
    public TextMeshProUGUI Counter;
    private void Awake()
    {
        Counter.text = " " +  __winCondition.GetHittedTargetsNumber;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GuitarTarget __collided = collision.gameObject.GetComponent<GuitarTarget>();
        if (__collided && !__collided.IsDestroyed && !__collided.IsDeactivated)
        {
            __collided.IsDeactivated = true;
            __winCondition.DeacreaseHittedTargets();
            Counter.text = " " + __winCondition.GetHittedTargetsNumber;
            //Debug.Log("Destroyed");
        }
    }
}
