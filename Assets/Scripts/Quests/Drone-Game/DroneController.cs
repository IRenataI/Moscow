using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class DroneController : MonoBehaviour
{
    public Vector3 DroneInitialPosition;
    public bool IsDroneEnable { get { return __isDroneEnable; } set { __isDroneEnable = value; } }
    public int SpeedX = 2;
    public int SpeedY = 2;
    public int SpeedZ = 2;
    public Camera DroneCamera;
    public Vector3 DroneCameraPosition = Vector3.zero;
    private Rigidbody __rigidBody;
    private Vector3 __x, __y, __z;
    private bool __isDroneEnable = false;
    void Awake()
    {
        __rigidBody = GetComponent<Rigidbody>();
        __rigidBody.useGravity = false;
        __rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void FixedUpdate()
    {
        if (!IsDroneEnable)
            return;

        DroneMovement();

        Debug.DrawRay(transform.position, DroneCamera.transform.forward, Color.red);
        Debug.DrawRay(transform.position, DroneCamera.transform.right, Color.green);
        Debug.DrawRay(transform.position, DroneCamera.transform.up, Color.blue);
    }
    private void DroneMovement()
    {
        __x = DroneCamera.transform.right * Input.GetAxis("Horizontal") * SpeedX;
        __y = DroneCamera.transform.forward * Input.GetAxis("Vertical") * SpeedY;
        __z = -DroneCamera.transform.up * SpeedZ * Convert.ToInt32(Input.GetKey(KeyCode.LeftControl))
            + DroneCamera.transform.up * SpeedZ * Convert.ToInt32(Input.GetKey(KeyCode.Space));

        //__rigidBody.velocity = new Vector3(
        //Mathf.Clamp(__rigidBody.velocity.x + Time.fixedDeltaTime, -10, 10),
        //
        //)
        __rigidBody.velocity = __x + __y + __z;

        DroneCamera.transform.localPosition = DroneCameraPosition;
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(DroneCamera.transform.forward), 0.05f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<DroneTargets>())
        {
            transform.position = DroneInitialPosition;
        }
    }
}
