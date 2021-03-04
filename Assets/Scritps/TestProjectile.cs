using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<Enemy>();

        if (collision.name != "Player")
        {
            if (target != null)
            {
                target.DealDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
