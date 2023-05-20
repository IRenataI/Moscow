using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraInteractable : MonoBehaviour
{
    [SerializeField] private float interactionMaxDistance;

    private Camera cam;
    private Interactable currentInteractable;
    
    private Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        SearchInteractable();
        Interact();
    }

    private void SearchInteractable()
    {
        Ray ray = cam.ScreenPointToRay(screenCenter);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactionMaxDistance))
        {
            Interactable interactable = hitInfo.transform.GetComponent<Interactable>();

            if (interactable == null)
            {
                if (currentInteractable != null)
                {
                    currentInteractable.Deselect();
                    currentInteractable = null;
                }

                return;
            }

            if (currentInteractable != null)
                currentInteractable.Deselect();

            currentInteractable = interactable;
            currentInteractable.Select();
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(GlobalVariables.InteractKey) != true || currentInteractable == null)
            return;

        currentInteractable.Interact();
    }
}