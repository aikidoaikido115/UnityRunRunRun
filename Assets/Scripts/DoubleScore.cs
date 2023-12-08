using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

class DoubleScore : Item
{
    [SerializeField]
    private GameManager gameManager;

    private float leftEdge;
    private bool isActivated;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        gameManager = GameManager.Instance;
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
        gameManager.scoreMultiplier = 2;
        await Task.Delay(10000);
        gameManager.scoreMultiplier = 1;
    }
}
