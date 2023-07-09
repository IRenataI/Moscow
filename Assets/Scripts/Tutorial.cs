using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] TutorialsObjects;
    private FirstPersonLook __camera;
    private FirstPersonMovement __player;
    private static Tutorial __instance;
    public static Tutorial GetInstance => __instance;
    private void Awake()
    {
        if (!__instance)
            __instance = this;
        else
            Destroy(gameObject);

        __camera = FindObjectOfType<FirstPersonLook>();
        __player = FindObjectOfType<FirstPersonMovement>();
    }
    public void EnableShootingTutorial()
    {
        __player.SetMovement(false);
        __camera.SetCameraRotation(false);

        CursorManager.EnableCursor();

        TutorialsObjects[0].gameObject.SetActive(true);
        TutorialsObjects[0].transform.GetComponentInChildren<Button>().onClick.AddListener( 
            () => DisableShootingTutorial());

        TutorialsObjects[0].transform.GetComponentInChildren<Button>().onClick.AddListener(
            () => ShootingManager.GetInstance.EnableShootingGame());
        Debug.Log("Shooting Tutorial Enabled");
    }
    public void DisableShootingTutorial()
    {
        __player.SetMovement(false);
        __camera.SetCameraRotation(true);

        CursorManager.DisableCursor();

        TutorialsObjects[0].gameObject.SetActive(false);
    }
}
