using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    [Tooltip("ลาก GameObject จุดเกิด (SpawnPoint) มาใส่ช่องนี้")]
    public Transform spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        // เช็คว่าวัตถุที่ตกลงมาโดน มี Tag ว่า "Player" หรือไม่
        if (other.CompareTag("Hero"))
        {
            // ดึงคอมโพเนนต์ CharacterController มาจากตัวผู้เล่น
            CharacterController charController = other.GetComponent<CharacterController>();

            if (charController != null)
            {
                // 1. ปิดการทำงานชั่วคราว เพื่อให้ยอมรับการย้ายตำแหน่ง
                charController.enabled = false;

                // 2. ย้ายตำแหน่งตัวผู้เล่นไปที่จุดเกิด
                other.transform.position = spawnPoint.position;

                // (ถ้าต้องการให้หันหน้าไปทางเดียวกับจุดเกิดด้วย ให้เปิดคอมเมนต์บรรทัดล่างนี้ครับ)
                // other.transform.rotation = spawnPoint.rotation;

                // 3. เปิดการทำงานกลับมาเหมือนเดิม
                charController.enabled = true;
            }
        }
    }
}