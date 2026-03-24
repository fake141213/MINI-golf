using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;

    void Start()
    {
        // InvokeRepeating("ชื่อฟังก์ชัน", เวลาเริ่ม, เวลาที่ทำซ้ำ);
        InvokeRepeating("SpawnCloud", 0f, 50f);
    }

    void SpawnCloud()
    {
        // ใช้ตำแหน่งของตัวนี้เลย
        // Instantiate(อะไร, ตำแหน่ง, การหมุน);
        Instantiate(cloudPrefab, transform.position, Quaternion.identity);
    }
}