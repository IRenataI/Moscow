using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float sensetivity;
    [SerializeField, Range(0f, 90f)] private float horizontalClampAngle;
    [SerializeField, Range(0f, 360f)] private float verticalClampAngle;

    private float horizontalAngle, verticalAngle;
    private bool canRotate = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        horizontalAngle = transform.eulerAngles.x;
        verticalAngle = transform.eulerAngles.y;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (!canRotate)
            return;

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

    public void StartRotate() => canRotate = true;
    public void StopRotate() => canRotate = false;
}