using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 8f;
    public float jumpHeight = 2.5f;
    public float gravity = -20f; // ปรับแรงโน้มถ่วงให้หนักแน่นขึ้นได้ตามใจชอบ

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // เช็คว่าเท้าแตะพื้นไหม (Character Controller มีคำสั่งนี้ในตัว)
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // ให้มีแรงกดลงพื้นนิดหน่อยเพื่อความเสถียร
        }

        // รับค่าการเดิน
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // คำนวณทิศทางตามกล้อง
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // ระบบกระโดด
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // สูตรคำนวณแรงกระโดดตามฟิสิกส์: v = sqrt(h * -2 * g)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // คำนวณแรงโน้มถ่วง
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}