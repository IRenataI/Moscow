using UnityEngine;

public class MonumentTrigger : MonoBehaviour
{
    private Dialog __dialog;
    private void Awake()
    {
        __dialog = GetComponent<Dialog>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            __dialog.EnableDialogCanvas();
        }
    }
}
