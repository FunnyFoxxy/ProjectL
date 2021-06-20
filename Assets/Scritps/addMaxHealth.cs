using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addMaxHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //hull heal
    {
        if(collision.CompareTag("Player")) //Inter player in trigger
        {
            PlayerStats.playerStats.maxHealth += 1;
            PlayerStats.playerStats.HealCharacter(PlayerStats.playerStats.maxHealth);
            GameObject.Find("Player").GetComponent<Animator>().SetTrigger("HealUp");
            Destroy(gameObject);
        }
    }
}
