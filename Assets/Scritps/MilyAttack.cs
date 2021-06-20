using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilyAttack : MonoBehaviour
{
    public float speed = 1.5f;
    public float damage;
    public float coolDown = 3;
    float time;
    Animator animator;
    private Vector2 direction;
    GameObject player;
    Vector2 playerPos;
    // Update is called once per frame
    private void Start()
    {
        time = coolDown;
        //player = FindObjectOfType<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)//InterCollicion on pplayer
    {
        if (collision.CompareTag("Player"))
        {
            if (time >= coolDown)
            {
                PlayerStats.playerStats.DealDamage(damage);
                time = 0;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //InterCollicion on pplayer
    {
        if (collision.CompareTag("Player") && time >= coolDown)
        {
            time = 0;
            PlayerStats.playerStats.DealDamage(damage);
        }
    }
    void DealDamage() //deal Damage
    {
        PlayerStats.playerStats.DealDamage(damage);
    }
    
    private void Update() 
    {
        time += Time.deltaTime;
        direction = Vector2.zero;
        playerPos = PlayerStats.playerStats.player.transform.position;
        if (playerPos.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }
}
