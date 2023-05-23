using UnityEngine;

[RequireComponent(typeof(WeaponAudio))]
public class Weapon : MonoBehaviour
{
    public bool IsWeaponEnable = false;
    public Camera Parent;
    public GameObject Bullet;
    public Vector3 LocalPosition;
    public Vector3 BulletPosition;
    [Range(1f, 15f)]
    public int BulletSpeed = 5;

    private GameObject __tempBullet;
    private RaycastHit __hit;
    private WeaponAudio _audio;
    private void Awake()
    {
        _audio = GetComponent<WeaponAudio>();
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
    }
    private void Position()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, LocalPosition, 0.1f);
    }
    private void Rotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(Camera.main.transform.forward), 0.05f);
    }
    private void Shoot()
    {
        __tempBullet = Instantiate(Bullet);
        Bullet bullet = __tempBullet.GetComponent<Bullet>();
        bullet.SetInitialPosition(transform.position + Parent.transform.forward);
        bullet.SetInitialRotation(Quaternion.LookRotation(__hit.point - (transform.position + Parent.transform.forward)));

        Ray __ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Physics.Raycast(__ray, out __hit, 500);
        if (__hit.point == Vector3.zero)
        {
            __hit.point = __ray.GetPoint(500);
        }

        bullet.SetInitialVelocity( (__hit.point - (transform.position + Parent.transform.forward)).normalized  * BulletSpeed); //Camera.main.transform.forward * BulletSpeed);
    }
    public void SetParent()
    {
        transform.parent = Parent.transform;
    }
    public void EnableWeapon()
    {
        IsWeaponEnable = true;
    }
    public void DisableWeapon()
    {

    }
}
//bullet.SetInitialRotation(Quaternion.LookRotation(transform.forward));