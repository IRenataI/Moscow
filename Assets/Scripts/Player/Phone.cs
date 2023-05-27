using System;
using UnityEngine;
using UnityEngine.Events;

public class Phone : MonoBehaviour
{
    [Serializable]
    public enum AnimationState
    {
        Inactive,
        Active,
        Camera,
        Social
    }

    [HideInInspector] public UnityEvent OnActivated;
    [HideInInspector] public UnityEvent OnDeactivated;
    [HideInInspector] public UnityEvent OnCameraOpen;

    private AnimationState currentAnimationState = AnimationState.Inactive;

    private Animator animator;

    private static Phone instance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(GlobalVariables.TakePhoneKey))
        {
            Default();
        }
        else if (Input.GetKeyDown(GlobalVariables.PutPhoneKey))
        {
            Deactivate();
        }
    }

    public void Default()
    {
        if (currentAnimationState == AnimationState.Active)
            return;

        Debug.Log("Default");

        animator.SetTrigger(AnimationState.Active.ToString());
        currentAnimationState = AnimationState.Active;
    }

    public void OpenCamera()
    {
        if (currentAnimationState == AnimationState.Camera)
            return;

        Debug.Log("Open Camera");

        animator.SetTrigger(AnimationState.Camera.ToString());
        currentAnimationState = AnimationState.Camera;
    }

    public void OpenSocial()
    {
        // DEBUG
        return;

        if (currentAnimationState == AnimationState.Social)
            return;

        Debug.Log("Open Social (fake)");
        //currentAnimationState = AnimationState.Social;
    }

    public void Deactivate()
    {
        if (currentAnimationState == AnimationState.Inactive)
            return;
        
        Debug.Log("Deactivate");

        animator.SetTrigger(AnimationState.Inactive.ToString());
        currentAnimationState = AnimationState.Inactive;
    }
}