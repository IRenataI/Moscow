using UnityEngine;

[RequireComponent(typeof(WeaponAudio))]
public class Weapon : MonoBehaviour
{
    public Quest TirQuest;
    [Range(0,25)]
    public int Ammo = 10;
    public bool IsWeaponEnable = false;
    public GameObject Bullet;
    public Vector3 LocalPosition;
    public int BulletPosition;
    [Range(1f, 15f)]
    public int BulletSpeed = 5;

    private Camera Parent;
    private GameObject __tempBullet;
    private RaycastHit __hit;
    private WeaponAudio _audio;
    private Vector3 __initialPosition;
    private Ray __ray;
    private BoxCollider __boxCollider;
    private int __initialAmmo;
    //private QuestSystem __questSystem;
    private void Awake()
    {
        _audio = GetComponent<WeaponAudio>();
        __initialPosition = transform.position;
        __boxCollider = GetComponent<BoxCollider>();

        Parent = Camera.main;
        __initialAmmo = Ammo;
        //__questSystem = FindObjectOfType<QuestSystem>();
    }
    void Update()
    {
        if (!IsWeaponEnable)           
            return;

        Position();
        Rotation();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            _audio.PlayShotSound();
        }

        __ray = new Ray(Parent.transform.position, Parent.transform.forward);
        Physics.Raycast(__ray, out __hit, 500);

        if (__hit.point == Vector3.zero)
        {
            __hit.point = __ray.GetPoint(500);
        }

        Debug.DrawRay(transform.position,
            (__hit.point - transform.position), Color.red);
    }
    private void Position()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, LocalPosition, 0.1f);
    }
    private void Rotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(__hit.point - transform.position), 0.05f);
    }
    private void Shoot()
    {
        if (Ammo <= 0)
        {
            DisableWeapon();
            TirQuest.InterruptQuest();
        }
        Ammo--;

        __tempBullet = Instantiate(Bullet);
        Bullet bullet = __tempBullet.transform.GetComponentInChildren<Bullet>();        

        bullet.SetInitialPosition(transform.position + Parent.transform.forward * BulletPosition);
        bullet.SetInitialVelocity( (__hit.point - bullet.transform.position).normalized * BulletSpeed);
    }
    public void EnableWeapon()
    {
        IsWeaponEnable = true;
        __boxCollider.enabled = false;

        transform.parent = Parent.transform;
    }
    public void DisableWeapon()
    {
        Ammo = __initialAmmo;
        IsWeaponEnable = false;
        transform.parent = null;

        transform.position = __initialPosition;
        __boxCollider.enabled = true;
    }
}
/*
public void SetParent()
{
    transform.parent = Parent.transform;
}
*/
//bullet.SetInitialRotation(Quaternion.LookRotation(transform.forward));

//bullet.SetInitialPosition(transform.position + Parent.transform.forward * BulletPosition);
//bullet.SetInitialRotation(Quaternion.LookRotation(__hit.point - (transform.position + Parent.transform.forward)));
//bullet.SetInitialVelocity( (__hit.point - (transform.position + Parent.transform.forward)).normalized * BulletSpeed); //Camera.main.transform.forward * BulletSpeed);

//bullet.SetInitialRotation(Quaternion.LookRotation(__hit.point - transform.position));