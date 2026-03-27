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

สมาชิกในการพัฒนาเกมส์ 1.นายกฤติน อินทร์ตระกูล รหัสนักศึกษา 673450032-2
                    2.นายจักรพงศ์ สำราญสิทธิ์ รหัสนักศึกษา 673450032-2

---

## 🙏 Thank You

ขอบคุณที่รับชมโปรเจกต์นี้ครับ
