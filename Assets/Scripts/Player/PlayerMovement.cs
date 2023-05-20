using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform cameraTransform;

    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float forward = Input.GetAxisRaw("Vertical");
        float right = Input.GetAxisRaw("Horizontal");
        Vector3 direction;

        if (cameraTransform)
            direction = forward * cameraTransform.forward + right * cameraTransform.right;
        else
            direction = forward * transform.forward + right * transform.right;

        direction.y = 0f;

        rb.velocity = speed * direction;
    }
}