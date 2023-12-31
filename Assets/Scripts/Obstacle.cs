using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime * 0.0221f;

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
