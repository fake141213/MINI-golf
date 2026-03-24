 using UnityEngine;
using UnityEngine.InputSystem; // ใช้ Input System ใหม่ของ Unity

public class GolfBall : MonoBehaviour
{
    Rigidbody rb; // ตัวแปรเก็บ Rigidbody ของลูกกอล์ฟ
    private LineRenderer lineRenderer; // ใช้สำหรับวาดเส้นเล็ง

    public float maxPower; // ความแรงในการตีลูก
    public float stopVelocity = 0.5f; // ความเร็วขั้นต่ำ ถ้าต่ำกว่านี้จะหยุดลูก

    private bool isIdle ; // ตรวจสอบว่าลูกหยุดนิ่งหรือไม่
    float shootTimer = 0f; // ตัวนับเวลาหลังยิง
    bool canStop = false;  // อนุญาตให้หยุดลูกหรือยัง

   public Canvas canvas;

    void Start()
    {
        // ดึง Rigidbody จาก Object นี้มาใช้งาน
        // ใช้สำหรับควบคุมการเคลื่อนที่ด้วยระบบฟิสิกส์ (Physics-based)
        rb = GetComponent<Rigidbody>();

        // ดึง LineRenderer จาก Object นี้มาใช้งาน
        // ใช้สำหรับวาดเส้นเล็งให้ผู้เล่นเห็นทิศทาง
        lineRenderer = GetComponent<LineRenderer>();

        // เริ่มต้นให้ซ่อนเส้นเล็ง
        lineRenderer.enabled = false;
        isIdle = true;
    }
    void Update()
    {
      if (canvas.gameObject.activeSelf == false)
      {
                    shootTimer += Time.deltaTime;

                        if(shootTimer >= 2f)
                        {
                            canStop = true;
                        }
                    // ตรวจสอบความเร็วของลูกกอล์ฟ
                    // ถ้าความเร็วต่ำกว่าที่กำหนด ให้หยุดลูก
                    if (rb.linearVelocity.magnitude < stopVelocity && !isIdle && canStop)
                    {
                        StopBall();
                    }
                    if (isIdle)
                    {
                        ProcessAim();
                    }
                    

                    // ถ้าคลิกเมาส์ซ้าย และลูกหยุดอยู่ → ตีลูก
                    if (Mouse.current.leftButton.wasPressedThisFrame && isIdle&& rb.linearVelocity.magnitude < stopVelocity)
                    {
                        ShootBall();
                    }
                }
      else
      {
        return;
      }
       
    }

    // ฟังก์ชันสำหรับการเล็งลูก
    void ProcessAim()
    {
        // สร้าง Ray จากกล้องไปตำแหน่งเมาส์
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        // ตรวจสอบว่า Ray ชน Object หรือไม่
        if (Physics.Raycast(ray, out hit))
        {
            // เปิดการแสดงเส้นเล็ง
            lineRenderer.enabled = true;

            // กำหนดจุดเริ่มต้นของเส้น (ตำแหน่งลูกกอล์ฟ)
            lineRenderer.SetPosition(0, transform.position);

            // กำหนดจุดปลายของเส้น (ตำแหน่งเมาส์บนพื้น)
            lineRenderer.SetPosition(1, hit.point);
        }
    }

    // ฟังก์ชันสำหรับตีลูกกอล์ฟ
    void ShootBall()
    {
        isIdle = false;
        rb.constraints = RigidbodyConstraints.None;
        // สร้าง Ray จากกล้องไปตำแหน่งเมาส์
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        

        // ถ้า Ray ชน Object
        if (Physics.Raycast(ray, out hit))
        {
            // หาทิศทางจากลูกไปตำแหน่งที่เมาส์ชี้
            Vector3 direction = hit.point - transform.position;

            // ไม่ให้ลูกลอยขึ้นในแกน Y
            direction.y = 0;
            float distance = direction.magnitude;

            // จำกัดแรงสูงสุด


            // คำนวณแรงตามระยะ
            // คำนวณแรงจากระยะที่ผู้เล่นเล็ง
            // distance = ระยะจากลูกกอล์ฟไปยังจุดที่เมาส์ชี้
            // ยิ่งเล็งไกล → ค่าระยะมาก → แรงมาก
            float finalPower = Mathf.Clamp(distance, 0, maxPower);
            // จำกัดค่าแรงไม่ให้เกิน maxPower
            // เพื่อป้องกันไม่ให้ลูกพุ่งแรงเกินไปจนควบคุมไม่ได้
            // ช่วยรักษาความสมดุลของเกม

            // ปรับสเกลแรงให้เหมาะกับฟีลการเล่นจริง
            // ค่า 1.4 เป็นค่าที่ได้จากการทดลอง (trial & error)
            // เพื่อให้แรงที่ได้ “รู้สึกสมจริง” และควบคุมง่ายขึ้น
            finalPower = finalPower*1.4f;

            // เพิ่มแรงให้ลูกกอล์ฟพุ่งไปตามทิศทาง
            // เพิ่มแรงแบบทันที (Impulse) ให้ลูกกอล์ฟพุ่งไปตามทิศทางที่เล็ง
            // direction.normalized = ทิศทาง (ไม่สนขนาด เอาแค่ทิศ)
            // finalPower = ขนาดของแรง (ยิ่งมาก → ยิ่งพุ่งแรง)
            // ForceMode.Impulse = ใส่แรงครั้งเดียวทันที เหมือนการ "ตีลูก"
            rb.AddForce(direction.normalized * finalPower, ForceMode.Impulse);

            // ซ่อนเส้นเล็งหลังจากตีลูก
            lineRenderer.enabled = false;

 
        // เพิ่มแรง
       

            // ตั้งค่าว่าลูกกำลังเคลื่อนที่

            shootTimer = 0f;
            canStop = false;
            
            // // แสดงข้อมูลใน Console สำหรับ Debug
            // Debug.Log("Ray Hit: " + hit.point + " Ball Position: " + transform.position);
             
        }
    }

    // ฟังก์ชันหยุดลูกกอล์ฟ
    void StopBall()
    {
        // ตั้งค่าความเร็วเป็น 0 เพื่อหยุดลูก
        rb.linearVelocity = Vector3.zero;

        // หยุดการหมุนของลูก
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // ตั้งค่าให้ลูกอยู่ในสถานะหยุดนิ่ง
        isIdle = true;
    }
}