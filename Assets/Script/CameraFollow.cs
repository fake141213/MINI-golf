using UnityEngine;

[ExecuteAlways]
public class CameraFollow : MonoBehaviour
{
    public Transform target; // ลูกกอล์ฟ
    public Vector3 offset; // ระยะห่างของกล้อง

    void LateUpdate()
    {
        // กล้องจะตามลูกกอล์ฟ
        transform.position = target.position + offset;

        // ให้กล้องมองไปที่ลูกกอล์ฟ
        transform.LookAt(target);
    }
}