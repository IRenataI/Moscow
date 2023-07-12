using TMPro;
using UnityEngine;

public class ShootingUI : MonoBehaviour
{
    private TextMeshProUGUI __ammoText;
    private Weapon __weapon;
    private void Awake()
    {
        __ammoText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        __weapon = FindAnyObjectByType<Weapon>();
    }
    private void FixedUpdate()
    {
        __ammoText.text = "Ammo: " + __weapon.GetAmmo;
    }
}
