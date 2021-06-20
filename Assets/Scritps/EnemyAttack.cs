using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected GameObject player;
    public SpriteRenderer enemySprite;
    public virtual void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        if(FindObjectOfType<PlayerMovement>().gameObject != null)
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    private void Update()
    {
        if (player.transform.position.x > transform.position.x)  //Поворот Протиивника
        {
            enemySprite.flipX = true;
        }
        else
        {
            enemySprite.flipX = false;
        }
    }
}
