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
    Renderer renderer; 
    // CS 0108 Warning
    
    public bool isBlinking = false;

    //public AudioClip dead;
    public AudioClip itemsound;
    public AudioClip destroysound;
    public AudioClip jumpsound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        renderer = GetComponent<Renderer>();
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
                audioSource.PlayOneShot(jumpsound);
            }
        }

        character.Move(direction * Time.deltaTime);

        // จะทำงานเมื่อเอฟเฟกต์ ghost ใกล้จะหมด : 
        if (isBlinking)
        {
            // ป้องกัน Loop
            isBlinking = false;

            // เริ่ม Blink
            StartCoroutine(blink());
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Obstacle") && !isInvincible)
        {
            // ถ้าผู้เล่นชนสิ่งกีดขวางตอนที่ไม่อมตะ
            
            FindObjectOfType<GameManager>().GameOver();
            //audioSource.PlayOneShot(dead);
        }
        if (target.CompareTag("Obstacle") && isInvincible)
        {
            // ถ้าผู้เล่นชนสิ่งกีดขวางตอนที่อมตะ พังเป้าหมายทิ้ง (เบิ้ม ๆ)
            Destroy(target.gameObject);
            audioSource.PlayOneShot(destroysound);
        }

        if (target.CompareTag("Item")) 
        {
            target.GetComponent<Item>().activate();
            Destroy(target.gameObject);
            audioSource.PlayOneShot(itemsound);
        }
    }



    IEnumerator blink()
    {
        float blinkDuration = 5f;
        while (blinkDuration > 0)
        {
            // Toggle the visibility of the GameObject : ChatGPT :)
            renderer.enabled = false;

            // Wait for a short duration (you can adjust the duration as needed)
            yield return new WaitForSeconds(0.25f);

            renderer.enabled = true;

            yield return new WaitForSeconds(0.25f);

            // Subtract the elapsed time from the total blink duration
            blinkDuration -= 0.5f;
        }

        // Ensure the GameObject is visible after the blinking is done
        renderer.enabled = true;
    }
}
