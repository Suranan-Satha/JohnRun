using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ช่องสำหรับใส่ตัว hero
    public float distance = 6f; // ระยะห่างของกล้องกับตัวละคร
    public float rotationSpeed = 3f; // ความเร็วตอนหันเมาส์

    private float mouseX;
    private float mouseY;

    void LateUpdate() // ใช้ LateUpdate เพื่อให้กล้องขยับตาม "หลังจาก" ที่ตัวละครเดินไปแล้ว กล้องจะได้ไม่กระตุก
    {
        // ถ้ายังไม่ได้ใส่ตัวละครให้กล้องตาม จะได้ไม่เกิด Error
        if (target == null) return;

        // รับค่าตอนที่เราขยับเมาส์ซ้าย-ขวา ขึ้น-ลง
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        // จำกัดมุมก้มเงยของกล้อง ไม่ให้มุดลงใต้ดินหรือตีลังกากลับหัว (ปรับเลขได้ตามชอบ)
        mouseY = Mathf.Clamp(mouseY, 10f, 60f);

        // คำนวณองศาการหมุนและตำแหน่งที่กล้องควรจะอยู่
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        // สั่งให้กล้องไปอยู่ที่ตำแหน่งนั้น และหันหน้ามองไปที่ตัวละครเสมอ
        transform.position = position;
        transform.LookAt(target.position);
    }
}