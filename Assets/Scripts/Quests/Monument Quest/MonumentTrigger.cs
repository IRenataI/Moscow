using UnityEngine;

public class MonumentTrigger : MonoBehaviour
{
    private Dialog __dialog;
    private Quest __quest;
    private void Awake()
    {
        __dialog = GetComponent<Dialog>();
        __quest = GetComponent<Quest>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FirstPersonMovement>() && !__quest.IsQuestCompleted)
        {
            __dialog.EnableDialogCanvas();
        }
    }
}
