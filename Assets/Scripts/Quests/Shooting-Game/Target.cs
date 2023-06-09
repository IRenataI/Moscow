using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Target : TargetsAbstract
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() && !__isDestroyed)
        {
            TargetHitSoundPlayer.Play();
            __isDestroyed = true;
            __winCondition.IncreaseHittedTargets();
        }
    }
}
