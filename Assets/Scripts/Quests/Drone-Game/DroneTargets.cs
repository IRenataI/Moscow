using UnityEngine;

public class DroneTargets : TargetsAbstract
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && !__isDestroyed)
        {
            __isDestroyed = true;
            __winCondition.IncreaseHittedTargets();
        }
    }
}
