using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<Enemy>();

        if (collision.tag != "Enemy")
        {
            if (collision.tag == "Player")
            {
                PlayerStats.playerStats.DealDamage(damage); 
            }

            Destroy(gameObject);
        }
    }
}
