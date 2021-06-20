using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGetScript : MonoBehaviour
{
    
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerStats.playerStats.imageKey.SetActive(true);
            Destroy(gameObject);
        }
    }
}
