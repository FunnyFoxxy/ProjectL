using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float progectileForce;
    public float range = 1;
    public float cost = 8;
    Vector2 finishPos;
    Animator animator;
    PlayerStats playerStatsSctipt;
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerStatsSctipt = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(1) &&playerStatsSctipt.staminaSlider.value > cost ) // Стрельба
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 MyPos = transform.position;
            Vector2 direction = (mousePos - MyPos).normalized;
            //finishPos = transform.position * direction * range;
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            
            spell.GetComponent<Rigidbody2D>().velocity = direction * progectileForce;
            spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage);

            playerStatsSctipt.staminaSlider.value -= cost;


        }

       
    }
}
