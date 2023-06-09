using UnityEngine;

public class DroneTargets : TargetsAbstract
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<DroneController>() && !__isDestroyed)
        {
            TargetHitSoundPlayer.Play();
            __isDestroyed = true;
            __winCondition.IncreaseHittedTargets();
            Debug.Log("drone target down " + gameObject.name);
        }
    }
}
