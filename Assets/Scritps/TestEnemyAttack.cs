using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public float minDamage = 1;
    public float maxDamage = 1;
    public float progectileForce;
    public float cooldown;

    private void Start()
    {
        StartCoroutine(ShootPlayer());
        if (player == null)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                player = FindObjectOfType<PlayerMovement>().gameObject;
            }
        }
    }

    IEnumerator ShootPlayer()
    {
        
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPosition = player.transform.position;
            Vector2 direction = (targetPosition - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * progectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }
        
    }
}
