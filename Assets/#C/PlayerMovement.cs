using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // ปรับความเร็วได้ในหน้า Inspector
    private Rigidbody rb;

    void Start()
    {
        // ดึงคอมโพเนนต์ Rigidbody ที่อยู่ในลูกบอลมาใช้งาน
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // ใช้ FixedUpdate กับเรื่องที่เกี่ยวกับฟิสิกส์
    {
        // รับค่าปุ่มลูกศร หรือ W A S D
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // สร้างทิศทางการกลิ้ง
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // ออกแรงผลักลูกบอล
        rb.AddForce(movement * speed);
    }
}