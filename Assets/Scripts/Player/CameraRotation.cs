using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float sensetivity;
    [SerializeField, Range(0f, 90f)] private float horizontalClampAngle;
    [SerializeField, Range(0f, 360f)] private float verticalClampAngle;

    private float horizontalAngle, verticalAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        horizontalAngle = transform.eulerAngles.x;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float xMove = -Input.GetAxis("Mouse Y");
        float yMove = Input.GetAxis("Mouse X");

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