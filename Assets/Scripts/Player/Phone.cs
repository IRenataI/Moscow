using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public enum AnimationState
    {
        Inactive,
        Active,
        Camera,
        SelfieCamera,
        Social,
        Notes,
        Bank
    }

    private Camera fpsCamera;

    [SerializeField] private Button returnToCameraButton;

    [HideInInspector] public UnityEvent OnActivated;
    [HideInInspector] public UnityEvent OnDeactivated;
    [HideInInspector] public UnityEvent OnCameraOpen;

    private AnimationState currentAnimationState = AnimationState.Inactive;

    private Animator animator;

    private FirstPersonLook fpsLook;
    private FirstPersonMovement fpsMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        fpsCamera = transform.parent.GetComponent<Camera>();
        fpsLook = fpsCamera?.GetComponent<FirstPersonLook>();
        fpsMovement = fpsCamera?.transform.parent.GetComponent<FirstPersonMovement>();
        
        returnToCameraButton.onClick.AddListener(OpenCamera);
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

        //// DEBUG
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    if (Cursor.lockState == CursorLockMode.Locked)
        //        Cursor.lockState = CursorLockMode.None;
        //    else
        //        Cursor.lockState = CursorLockMode.Locked;
        //}
        //// DEBUG
    }

    public void Default()
    {
        if (currentAnimationState == AnimationState.Active)
            return;

        Debug.Log("Default");
        Cursor.lockState = CursorLockMode.None;
        animator.SetTrigger(AnimationState.Active.ToString());
        currentAnimationState = AnimationState.Active;
        fpsCamera.enabled = true;
    }

    public void OpenCamera()
    {
        if (currentAnimationState == AnimationState.Camera)
            return;

        Debug.Log("Open Camera");

        animator.SetTrigger(AnimationState.Camera.ToString());
        currentAnimationState = AnimationState.Camera;
        fpsCamera.enabled = true;
        PlayerAnimations.SetSelfieAnimation(false);
        //fpsLook.SetCameraRotation(true);
        fpsLook.xScale = 1f;
        returnToCameraButton?.gameObject.SetActive(false);
        fpsMovement.SetMovement(true);
    }

    public void OpenSelfieCamera()
    {
        if (currentAnimationState == AnimationState.SelfieCamera)
            return;

        Debug.Log("Open Selfie Camera");

        animator.SetTrigger(AnimationState.SelfieCamera.ToString());
        currentAnimationState = AnimationState.SelfieCamera;
        fpsCamera.enabled = false;
        PlayerAnimations.SetSelfieAnimation(true);
        //fpsLook.SetCameraRotation(false);
        fpsLook.xScale = 0f;
        returnToCameraButton?.gameObject.SetActive(true);
        fpsMovement.SetMovement(false);
        
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
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetTrigger(AnimationState.Inactive.ToString());
        currentAnimationState = AnimationState.Inactive;
        fpsCamera.enabled = true;
        PlayerAnimations.SetSelfieAnimation(false);
        //fpsLook.SetCameraRotation(true);
        fpsLook.xScale = 1f;
        returnToCameraButton?.gameObject.SetActive(false);
        fpsMovement.SetMovement(true);
    }
}