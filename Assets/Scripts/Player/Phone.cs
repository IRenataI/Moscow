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
        Social,
        Notes,
        Bank
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
            if(currentAnimationState == AnimationState.Inactive)
                Default();
            else
                Deactivate();
        }


        // DEBUG
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
        // DEBUG
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
        if (currentAnimationState == AnimationState.Social)
            return;

        Debug.Log("Open Social");

        animator.SetTrigger(AnimationState.Social.ToString());
        currentAnimationState = AnimationState.Social;
    }

    public void OpenNotes()
    {
        if (currentAnimationState == AnimationState.Notes)
            return;

        Debug.Log("Open Notes");

        animator.SetTrigger(AnimationState.Notes.ToString());
        currentAnimationState = AnimationState.Notes;
    }

    public void OpenBank()
    {
        if (currentAnimationState == AnimationState.Bank)
            return;

        Debug.Log("Open Bank");

        animator.SetTrigger(AnimationState.Bank.ToString());
        currentAnimationState = AnimationState.Bank;
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