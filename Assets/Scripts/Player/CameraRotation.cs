using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotation : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float sensetivity;
    [SerializeField, Range(0f, 90f)] private float horizontalClampAngle;
    [SerializeField, Range(0f, 360f)] private float verticalClampAngle;

    private float horizontalAngle, verticalAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        horizontalAngle = transform.eulerAngles.x;
        verticalAngle = transform.eulerAngles.y;
    }

    private void Update()
    {
        // DEBUG
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
        // DEBUG

        Rotate();
    }

    private void Rotate()
    {
        float xMove = -Input.GetAxis(GlobalVariables.HorizontalRotateAxis);
        float yMove = Input.GetAxis(GlobalVariables.VerticalRotateAxis);

        horizontalAngle += xMove * sensetivity * Time.deltaTime;
        horizontalAngle = Mathf.Clamp(horizontalAngle, -horizontalClampAngle, horizontalClampAngle);

        verticalAngle += yMove * sensetivity * Time.deltaTime;
        VecticalAngleClamp();

        transform.eulerAngles = new Vector3(horizontalAngle, verticalAngle, 0f);
    }

    private void VecticalAngleClamp()
    {
        if (verticalClampAngle == 360f)
        {
            if (verticalAngle >= verticalClampAngle)
                verticalAngle -= verticalClampAngle;
            else if (verticalAngle <= -verticalClampAngle)
                verticalAngle += verticalClampAngle;
        }
        else
        {
            if (verticalAngle > verticalClampAngle)
                verticalAngle = verticalClampAngle;
            else if (verticalAngle < -verticalClampAngle)
                verticalAngle = -verticalClampAngle;
        }
    }
}