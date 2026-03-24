using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastExample : MonoBehaviour
{
    void Update()
    {
        // ตรวจสอบว่าคลิกเมาส์ซ้ายหรือไม่
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        // สร้าง Ray จากกล้องไปตำแหน่งเมาส์
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit hit;

        // ยิง Ray เพื่อตรวจสอบการชน
        if (Physics.Raycast(ray, out hit))
        {
            // วาดเส้นสีแดงจากกล้องไปตำแหน่งที่ชน
            Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);

            // แสดงชื่อ Object ที่ Ray ชน
            Debug.Log("Ray Hit: " + hit.collider.name);
            Debug.Log(ray.origin+ hit.point);
        }
    }
}