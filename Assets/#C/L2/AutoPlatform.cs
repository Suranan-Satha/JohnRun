using UnityEngine;

public class AutoPlatform : MonoBehaviour
{
    private Vector3 startPosition;

    [Tooltip("ระยะทางและทิศทางที่อยากให้ขยับ (เช่น ใส่ Z = 5 คือเลื่อนไปข้างหน้า 5 หน่วย)")]
    public Vector3 moveAmount = new Vector3(0, 0, 5f);

    [Tooltip("ความเร็วในการเลื่อน")]
    public float speed = 1f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, 1f);

        transform.position = Vector3.Lerp(startPosition, startPosition + moveAmount, movement);
    }
}