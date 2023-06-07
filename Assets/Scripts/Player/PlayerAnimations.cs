using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Transform __parent;
    private Rigidbody __parentRigidbody;
    private Animator __animator;
    private void Awake()
    {
        __parent = transform.parent;
        __parentRigidbody = __parent?.GetComponent<Rigidbody>();
        __animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (__parentRigidbody.velocity.magnitude > 0.5f)
        {
            __animator.SetBool("Idle", false);
            __animator.SetBool("Walking", true);
        }else
        {
            __animator.SetBool("Idle", true);
            __animator.SetBool("Walking", false);
        }
    }
}
