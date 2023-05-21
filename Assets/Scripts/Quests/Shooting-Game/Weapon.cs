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
    void Update()
    {
        if (!IsWeaponEnable)
        {           
            return;
        }
        Position();
        Rotation();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Position()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, LocalPosition, 0.1f);
    }
    private void Rotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.LookRotation(Parent.transform.forward), 0.05f);
    }
    private void Shoot()
    {
        __tempBullet = Instantiate(Bullet);
        Bullet bullet = __tempBullet.GetComponent<Bullet>();
        bullet.SetInitialPosition(transform.position + Parent.transform.forward);
        bullet.SetInitialRotation(Quaternion.LookRotation(transform.forward));
        bullet.SetInitialVelocity(transform.forward * BulletSpeed);
    }
}
