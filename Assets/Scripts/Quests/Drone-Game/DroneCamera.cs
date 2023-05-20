using UnityEngine;

public class DroneCamera : MonoBehaviour
{
    [SerializeField] private float sensetivity;
    [SerializeField, Range(0f, 90f)] private float horizontalClampAngle;
    [SerializeField, Range(0f, 360f)] private float verticalClampAngle;

    private float horizontalAngle, verticalAngle;
    private RaycastHit __hit;
    float xMove, yMove;
    private void FixedUpdate()
    {
        Rotate();
    }
    private void Update()
    {
        xMove = -Input.GetAxis("Mouse Y");
        yMove = Input.GetAxis("Mouse X");
    }
    private void Rotate()
    {
        horizontalAngle += xMove * sensetivity * Time.deltaTime;
        horizontalAngle = Mathf.Clamp(horizontalAngle, -horizontalClampAngle, horizontalClampAngle);

        verticalAngle += yMove * sensetivity * Time.deltaTime;

        if (verticalAngle >= 360f)
            verticalAngle -= 360f;
        else if (verticalAngle <= 360f)
            verticalAngle += 360f;

        transform.eulerAngles = new Vector3(horizontalAngle, verticalAngle, 0f);
    } 
}
