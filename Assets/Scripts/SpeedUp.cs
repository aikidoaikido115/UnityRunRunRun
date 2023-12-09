using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// Inherits (and maybe polymorph) from class GhostPowerup
class SpeedUp : GhostPowerup
{
    [SerializeField]
    private GameManager gameManager;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        currentPlayer = FindObjectOfType<Player>();
        gameManager = GameManager.Instance;
    }
    async public override void activate()
    {
        // float speedIncrease = gameManager.gameSpeed * 1.5f;
        // Make player run faster and immune to obstacle collisions
        ghost();
        float speedIncrease = 500f + (gameManager.gameSpeed / 3);
        // If set in GM is private, can't access the thing
        gameManager.gameSpeed += speedIncrease;
        await Task.Delay(11000); // Effects last for 11 full seconds before fading
        for (int seconds = 0; seconds < 4; seconds++) {
            // The effect fade down each seconds out of 4 seconds
            await Task.Delay(1000);
            gameManager.gameSpeed -= speedIncrease/4;
        }
        
        // Ran with another 5 seconds with normal speed before ghost effect ran out
    }
}
