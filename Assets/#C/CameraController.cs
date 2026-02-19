using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float distance = 6f; 
    public float rotationSpeed = 3f; 

    private float mouseX;
    private float mouseY;

    void LateUpdate() 
    {
        if (target == null) return;

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        mouseY = Mathf.Clamp(mouseY, 10f, 60f);

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        transform.position = position;
        transform.LookAt(target.position);
    }
}