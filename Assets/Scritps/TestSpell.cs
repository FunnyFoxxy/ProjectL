using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float progectileForce;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 MyPos = transform.position;
            Vector2 direction = (mousePos - MyPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * progectileForce;
            spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
