using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading.Tasks;
using static UnityEngine.GraphicsBuffer;

class JumpBoost : Item
{
    private float leftEdge;
    private Player currentPlayer;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        currentPlayer = FindObjectOfType<Player>();
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime * 0.0221f;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }


    async public override void activate()
    {
        // Make player jump higher and fall slower (lower gravity)
        currentPlayer.gravity = 8.0f * 2f;
        currentPlayer.jumpForce = 10.0f;
        // Wait for effect to ran out (Temporary 10 seconds)
        await Task.Delay(10000);
        // If effect ran out, back to normal gravity and jump force
        currentPlayer.gravity = 9.81f * 2f;
        currentPlayer.jumpForce = 8f;
    }
    
}
