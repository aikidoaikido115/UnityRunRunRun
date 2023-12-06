using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// Inherits from an abstract class Item
class GhostPowerup : Item
{
    protected float leftEdge;
    protected Player currentPlayer;
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


    public override void activate()
    {
        // Make player immune to collisions when pick up the item
        ghost();
    }

    async public void ghost()
    {
        currentPlayer.isInvincible = true; // ��������������
        currentPlayer.ghostInEffect += 1; // �������㹵���� ghostInEffect ������ա�����¡���Ϳ࿡������
        await Task.Delay(11000); // Effect lasts for 15 seconds

        currentPlayer.isBlinking = true;

        await Task.Delay(4000);
        currentPlayer.ghostInEffect -= 1; // ������Ф��������Ϳ࿡�� ghost ���ӧҹ��������˹��
        if (currentPlayer.ghostInEffect == 0)
        {   // �Ϳ࿡���������ó�Ŵ�����͡�ҡ������
            currentPlayer.isInvincible = false;
        }
    }
    /*
    void blink()
    {
        Renderer renderer = currentPlayer.GetComponent<Renderer>();
        renderer.enabled = false;
    }

    void stopBlinking() {
        Renderer renderer = currentPlayer.GetComponent<Renderer>();
        renderer.enabled = true;
    }
    */
}
