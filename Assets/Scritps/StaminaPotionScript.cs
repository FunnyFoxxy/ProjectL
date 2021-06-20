using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPotionScript : MonoBehaviour
{
    PlayerStats playerStatsScript;
    float timer;
    bool trg;
    private void Start()
    {
        playerStatsScript = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerStatsScript.staminaPotion = true;
            Destroy(gameObject);
        }
    }
    
    
}
