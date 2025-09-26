using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float lifet = 3f;
    void Start()
    {
        Destroy(gameObject,lifet);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.player.Damage();
        }
        Destroy(gameObject);
    }
}
