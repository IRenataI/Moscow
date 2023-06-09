using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Transform __parent;
    private Rigidbody __parentRigidbody;
    private Animator __animator;
    
    private static PlayerAnimations __instance;
    
    private void Awake()
    {
        __instance = this;
        __parent = transform.parent;
        __parentRigidbody = __parent?.GetComponent<Rigidbody>();
        __animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (__animator.GetBool("Selfie"))
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                __animator.SetBool("Selfie", false);
                __animator.SetBool("Idle", true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!__animator.GetBool("Selfie"))
        {
            if (__parentRigidbody.velocity.magnitude > 0.5f)
            {
                __animator.SetBool("Idle", false);
                __animator.SetBool("Walking", true);
            }
            else
            {
                __animator.SetBool("Idle", true);
                __animator.SetBool("Walking", false);
            }
        }
    }

    public static void SetSelfieAnimation(bool value)
    {
        if (value)
        {
            __instance.__animator.SetBool("Idle", false);
            __instance.__animator.SetBool("Walking", false);
            __instance.__animator.SetBool("Selfie", true);
        }
        else
        {
            __instance.__animator.SetBool("Idle", true);
            __instance.__animator.SetBool("Walking", false);
            __instance.__animator.SetBool("Selfie", false);
        }
    }
}
