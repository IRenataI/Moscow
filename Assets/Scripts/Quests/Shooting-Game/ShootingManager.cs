using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    private Weapon __weapon;
    private Canvas __ui;

    private FirstPersonLook __cam;
    private FirstPersonMovement __move;

    private static ShootingManager __instance;
    public static ShootingManager GetInstance => __instance;
    private Quest __quest;
    private void Awake()
    {
        if (!__instance)
            __instance = this;
        else
            Destroy(gameObject);

        __weapon = FindObjectOfType<Weapon>();
        __ui = FindObjectOfType<ShootingUI>().GetComponent<Canvas>();

        __cam = FindObjectOfType<FirstPersonLook>();
        __move = FindObjectOfType<FirstPersonMovement>();

        __weapon.SetTirQuest = GetComponent<Quest>();

        __quest = GetComponent<Quest>();


        __quest.EventOnEnd.AddListener(() => DisableShootingGame());
        __quest.EventOnInterrupt.AddListener(() => DisableShootingGame());
    }
    public void EnableShootingGame()
    {
        __weapon.EnableWeapon();
        __ui.enabled = true;

        __cam.SetCameraRotation(true);
    }
    public void DisableShootingGame()
    {
        __move.SetMovement(true);

        __weapon.DisableWeapon();
        __ui.enabled = false;
    }
}
