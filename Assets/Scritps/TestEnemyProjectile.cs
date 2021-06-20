using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<Enemy>();

        if (collision.tag != "Enemy") //Вражеский снаряд попадает в цель
        {
            if (collision.tag == "Player")
            {
                PlayerStats.playerStats.DealDamage(damage);
                DestroyThis();
            }
            if (target != null)
            {
                target.DealDamage(damage);
                Destroy(gameObject);
            }
            if (collision.tag == "Wall" || collision.tag == "Door" || collision.tag == "DoorLocation" || collision.tag == "Block")
            {
                DestroyThis();
            }

        }
        if (collision.isTrigger)
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
