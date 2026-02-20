using UnityEngine;

public class playerStat : MonoBehaviour
{
    public int hp = 90;   // ค่าเริ่มต้น HP

    private Renderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("enemy")) return;

        Color c = playerRenderer.material.color;

        int damage;
        if (c == Color.green) damage = 1;
        else if (c == Color.yellow) damage = 10;
        else if (c == Color.red) damage = 20;
        else damage = 15;

        hp -= damage;
        if (hp < 0) hp = 0; // กันติดลบ
    }
}