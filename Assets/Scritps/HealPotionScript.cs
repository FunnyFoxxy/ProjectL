using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotionScript : MonoBehaviour
{
    public float heal = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().HealCharacter(heal);
            Destroy(gameObject);
        }
    }
}
