using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class Bullet : MonoBehaviour
{
    private Rigidbody __rigidBody;
    private void Awake()
    {
        __rigidBody = GetComponent<Rigidbody>();
        __rigidBody.useGravity = false;
    }
    public void SetInitialPosition(Vector3 Position)
    {
        transform.position = Position;
    }
    public void SetInitialRotation(Quaternion Rotation)
    {
        transform.rotation = Rotation;
    }
    public void SetInitialVelocity(Vector3 Velocity)
    {
        __rigidBody.velocity = Velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
