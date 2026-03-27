# ⛳ Mini Golf Game (Unity)

## 📌 Overview

โปรเจกต์นี้เป็นเกม **Mini Golf 3D** ที่พัฒนาด้วย Unity Engine
โดยผู้เล่นต้องควบคุมทิศทางและแรงในการตีลูกกอล์ฟให้ลงหลุมโดยใช้จำนวนครั้งให้น้อยที่สุด

---

## Features

* 🎯 ระบบเล็งด้วย Raycast (Real-time)
* 🏌️‍♂️ ระบบยิงลูกด้วย Physics (Rigidbody + Force)
* 📏 คำนวณแรงจากระยะทาง (Vector Calculation)
* 🧲 ระบบหยุดลูกอัตโนมัติ (Velocity Check)
* 🖥️ UI ควบคุมเกม (Next / Restart / Menu)
* 🎥 กล้องติดตามลูกแบบ Smooth

---

## 🧠 Core Systems

### Raycast System

ใช้ตรวจจับตำแหน่งเมาส์ในโลก 3D
เพื่อแปลง input จาก 2D → 3D

### Ball Controller (GolfBall.cs)

* ควบคุมการเล็ง ยิง และการเคลื่อนที่
* ใช้ Vector ในการคำนวณ direction และแรง
* ใช้ State เช่น `isIdle` เพื่อควบคุม flow

### UI System

* เปลี่ยน Scene
* รีสตาร์ทเกม
* ออกจากเกม

### Camera System

* กล้องตามลูกแบบ real-time
* ใช้ LateUpdate ลดอาการกระตุก

---

## 🗺️ Game Flow

```text
Player Input (Mouse)
        ↓
Raycast Detection
        ↓
Aim System (LineRenderer)
        ↓
Shoot (AddForce)
        ↓
Ball Movement (Physics)
        ↓
Stop Condition
        ↓
Trigger (Hole)
        ↓
UI Show → Next Level
```

---

## 🗓️ Development Timeline

### 🟢 Phase 1: Setup Project

* สร้าง Unity Project
* สร้างฉาก (Scene) และพื้นฐานของเกม
* เพิ่มลูกกอล์ฟ + Collider + Rigidbody

---

### 🟡 Phase 2: Core Gameplay

* เขียนระบบ **Raycast**
* ทำระบบ **Aim (LineRenderer)**
* ทำระบบ **ShootBall()**
* คำนวณ direction, distance, normalized

---

### 🟠 Phase 3: Physics & Logic

* เพิ่มระบบหยุดลูก (`stopVelocity`)
* เพิ่ม Timer กันบัค (`shootTimer`)
* ปรับค่าความแรง (Clamp + Multiplier)

---

### 🔵 Phase 4: UI System

* สร้าง Canvas
* เขียน UI.cs (Next / Restart / Menu)
* เขียน UISET.cs (Trigger เปิด UI)

---

### 🟣 Phase 5: Camera System

* ทำ CameraFollow.cs
* ใช้ offset + LookAt
* ปรับให้ smooth ด้วย LateUpdate

---

### 🔴 Phase 6: Polish & Testing

* ปรับค่า Physics ให้เล่นลื่น
* ทดสอบการชนและการหยุด
* แก้ bug และปรับ UX

---

## ⚙️ Technologies Used

* Unity Engine
* C#
* Physics System (Rigidbody)
* Raycast
* Scene Management

---

## 📚 What I Learned

* การใช้ **Raycast ในโลก 3D**
* การคำนวณ **Vector (direction, magnitude, normalized)**
* การจัดการ **Game Flow และ State**
* การใช้ **Physics ใน Unity**
* การออกแบบระบบ UI และ Scene

---

## 🚀 Future Improvements

* เพิ่มระบบนับจำนวนครั้งการตี
* เพิ่มหลายด่าน (Level System)
* เพิ่มเสียงและเอฟเฟกต์
* เพิ่มระบบ Power Bar
* ปรับกล้องให้มีการ Zoom

---

## 👥 Credits

สมาชิกในการพัฒนาเกมส์ 1.นายกิตติศักดิ์ ขันแข็ง รหัสนักศึกษา 673450031-4
                    2.นายจักรพงศ์ สำราญสิทธิ์ รหัสนักศึกษา 673450032-2
<img width="1780" height="810" alt="MiniGolf_Member" src="https://github.com/user-attachments/assets/593c7d02-3d01-4ef3-88c8-1fc96e8d6b97" />

                    

---

## 🎮 Gameplay Preview
![ray](https://github.com/user-attachments/assets/1020d1c3-dfd7-4214-a898-824af79eb1b3)
หน้าหลักของเกม ผู้เล่นสามารถกด Play เพื่อเริ่มเกม หรือ Exit เพื่อออกจากเกม ผู้เล่นใช้เมาส์ในการเล็งทิศทางของลูกกอล์ฟ โดยระบบจะคำนวณแรงยิงจากระยะทางระหว่างลูกกับตำแหน่งที่คลิก

![การยิงลูก (4)](https://github.com/user-attachments/assets/80de144f-7ab3-4374-8d14-39b034d3d22b)

เมื่อผู้เล่นคลิกเพื่อยิง ระบบจะใช้ Raycast กำหนดตำแหน่งเป้าหมาย จากนั้นคำนวณเวกเตอร์ทิศทาง (direction) และแรง (force) ก่อนนำไปใช้กับ AddForce() ของ Rigidbody ทำให้ลูกกอล์ฟเคลื่อนที่ตามหลักฟิสิกส์

![scene ลงหลุมด่าน 1](https://github.com/user-attachments/assets/998aae05-20ed-4bda-8b04-9805f02828a1)
เมื่อผู้เล่นทำลูกลงหลุม ระบบจะ Trigger การแสดง UI และหยุดการควบคุม จากนั้นผู้เล่นสามารถเลือกไปยังด่านถัดไป ซึ่งระบบจะทำการโหลด Scene ใหม่ (Next Stage) เพื่อเริ่ม Gameplay ในเลเวลถัดไป

![restart ลูก](https://github.com/user-attachments/assets/e80c73dd-94ea-43fb-9adc-e72c3db63d3a)
ผู้เล่นสามารถกดปุ่ม Restart เพื่อโหลด Scene ปัจจุบันใหม่ (Reload Scene) ซึ่งจะรีเซ็ตตำแหน่งลูกกอล์ฟและสถานะต่าง ๆ ของด่านกลับไปยังค่าเริ่มต้น


## 🙏 Thank You

ขอบคุณที่รับชมโปรเจกต์นี้ครับ
