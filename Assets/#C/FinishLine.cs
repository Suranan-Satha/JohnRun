using UnityEngine;
using UnityEngine.SceneManagement; // จำเป็นต้องมีบรรทัดนี้เพื่อเรียกใช้ระบบสลับฉาก

public class FinishLine : MonoBehaviour
{
    public string nextSceneName = "Level2"; // พิมพ์ชื่อด่านถัดไปรอไว้ได้เลย

    // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อมีวัตถุเข้ามาใน Trigger
    void OnTriggerEnter(Collider other)
    {
        // เช็คว่าวัตถุที่เข้ามาคือลูกบอลของเราใช่ไหม
        if (other.CompareTag("Hero"))
        {
            Debug.Log("Load...");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}