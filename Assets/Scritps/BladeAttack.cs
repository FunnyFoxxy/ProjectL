using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeAttack : MonoBehaviour
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

        animator = GetComponent<Animator>();
        //player = FindObjectOfType<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //begin attck
    {
        if (collision.CompareTag("Player"))
        {
            print("CanAttack");
            animator.SetBool("CanAttack", true);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //contue Attack
    {
        if (collision.CompareTag("Player") && time >= coolDown)
        {
            time = 0;
        }
    }
    void DealDamage() //Attack
    {
        PlayerStats.playerStats.DealDamage(damage);
    }
    private void OnTriggerExit2D(Collider2D collision) // player escaped
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("CanAttack", false);
        }
    }
    private void Update() // just update :)
    {
        time += Time.deltaTime;
        direction = Vector2.zero;
        playerPos = PlayerStats.playerStats.player.transform.position;
        if(playerPos.x < transform.position.x) //moveing to player
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        if(GetComponent<Enemy>().health == 0) // killer is dead...
        {
            animator.SetTrigger("Death");
        }

    }
}
