using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// Inherits from an abstract class Item
class GhostPowerup : Item
{
    protected float leftEdge;
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

    
    public override void activate(Player player)
    {
        // Make player immune to collisions when pick up the item
        ghost(player);
    }

    async public void ghost(Player player)
    {
        // Make player able to run through obstacle
        // player.invincible = true; : Require addition L value in Player class. Any better solutions?
        // ทำอย่างนี้ได้เช่นกัน แต่ผู้เล่นจะเดินผ่านทุกอย่างรวมไอเท็มด้วย
        Collider playerCollider = player.GetComponent<Collider>();
        playerCollider.enabled = false;

        await Task.Delay(1000); // Effect lasts for 10 seconds
        // player.invincible = false;
        playerCollider.enabled = true;
    }
}
