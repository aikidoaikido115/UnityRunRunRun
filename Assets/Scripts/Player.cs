using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;
    public float gravity = 9.81f * 2f; //ไดโนเสาร์มันจะลอยนานเกินไป
    public float jumpForce = 8f;
    public bool isInvincible = false; // ระบุว่าผู้เล่นเป็นอมตะหรือไม่
    public int ghostInEffect = 0; // กรณีที่มีเอฟเฟกต์อมตะซ้อนกันให้การทับซ้อนเหลือ 0 แล้วค่อยปลดอมตะ

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Obstacle") && !isInvincible)
        {   
            // ถ้าผู้เล่นชนสิ่งกีดขวางตอนที่ไม่อมตะ
            FindObjectOfType<GameManager>().GameOver();
        }
        if (target.CompareTag("Item")) 
        {
            target.GetComponent<Item>().activate();
            Destroy(target.gameObject);
        }
    }

}
