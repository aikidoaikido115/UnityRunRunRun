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
        gameManager = GameManager.Instance;
    }
    async public override void activate(Player player)
    {
        // Make player run faster and immune to obstacle collisions
        ghost(player);
        // If set in GM is private, can't access the thing
        gameManager.gameSpeed += 500f;
        await Task.Delay(5000); // Effects last for 5 full seconds before fading
        for (int i = 0; i < 5; i++) {
            // The effect fade down each seconds out of 4 seconds
            await Task.Delay(1000);
            gameManager.gameSpeed -= 100f;
        }
    }
}
