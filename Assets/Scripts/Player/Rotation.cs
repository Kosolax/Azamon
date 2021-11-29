using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float MouseSensitivity;

    public Transform XRotationTransform;

    public Transform YRotationTransform;

    private float xRotation = 0f;

    public void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * this.MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * this.MouseSensitivity;

        xRotation -= mouseY;

        // don't allow people to rotate verticall to much
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        this.YRotationTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        this.XRotationTransform.Rotate(Vector3.up * mouseX);
    }
}