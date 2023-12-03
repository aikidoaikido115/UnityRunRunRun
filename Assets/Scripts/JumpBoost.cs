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
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime * 0.0221f;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }


    async public override void activate(Player player)
    {
        // Make player jump higher and fall slower (lower gravity)
        player.gravity = 8.0f * 2f;
        player.jumpForce = 10.0f;
        // Wait for effect to ran out (Temporary 5 seconds)
        await Task.Delay(5000);
        // If effect ran out, back to normal gravity and jump force
        player.gravity = 9.81f * 2f;
        player.jumpForce = 8f;
    }
    
}
