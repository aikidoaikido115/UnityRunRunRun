# CactusRun

## คำอธิบาย
เกมวิ่ง 2D ที่ได้ไอเดียมาจากเกมไดโนเสาร์กระโดดข้ามกระบองเพชรโดยตัวเกมได้มีการปรับปรุงฉากให้มีสีสันมากขึ้น
มีไอเทมเพิ่มความสามารถและสิ่งกีดขวางที่มีความยากเพิ่มขึ้น

## สารบัญ
- [การติดตั้ง](#การติดตั้ง)
- [การใช้งาน](#usage)
- [ฟีเจอร์](#ฟีเจอร์)
- [ภาพตัวอย่างเกม](#ภาพตัวอย่างเกม)

## การติดตั้ง
กรณีจะดาวน์โหลดไฟล์เกม .exe มาลองเล่นสามารถโหลดได้ที่ https://drive.google.com/drive/folders/1-QqN8j2cuOJX_qSRBG2GDOFjkqnsPMi6?usp=sharing
ให้ดาวน์โหลดมาทั้งหมดแล้วสร้างโฟลเดอร์ใหม่แล้วลากลงไป
หรือจะ clone ตัวโปรเจคมาเลย


```bash
# Clone the repository
git clone https://github.com/aikidoaikido115/UnityRunRunRun.git
```

##  การใช้งาน
- ติดตั้ง Unity
- เปิด Unity hub
- import Project เข้ามา
- เปิด main scene
- ลองทดสอบหรือแก้ไขโปรเจคได้

## ฟีเจอร์
- สิ่งกีดขวางที่ยากขึ้น
    - บังคับให้กระโดดขึ้นชั้น 2 ไม่งั้นจะตายทันที
    - บังคับให้เก็บไอเทม ghost ไม่งั้นจะเจอกับสิ่งกีดขวางที่สูงมากไม่สามารถกระโดดข้ามได้
- ไอเทม
    - speedup (วิ่งไวชนสิ่งกีดขวางแล้วไม่ตาย)
    - ghost (อมตะ)
    - scoreX2
    - jumpboost
- มีเพลงประกอบ มีเสียงเอฟเฟคกระโดด/เก็บไอเทม/ชนสิ่งกีดขวางตอนมีไอเทม/ตาย(อันนี้คอนเทนต์เลย)
- บันทึก High Score
- สลับภาพพื้นหลังระหว่างตอนกลางวัน กับตอนเย็น


## ภาพตัวอย่างเกม
![Screenshot 1](/img/Picture1.png)
![Screenshot 2](/img/Picture2.png)
![Screenshot 3](/img/Picture3.png)
![Screenshot 4](/img/Picture4.png)
![Screenshot 5](/img/Picture5.png)
![Screenshot 6](/img/Picture6.png)

