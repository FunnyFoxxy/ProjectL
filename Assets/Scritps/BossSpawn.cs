using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    bool spawned = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!spawned)
            {
                if (Random.Range(0, 2) == 1)
                {
                    Instantiate(Boss, transform.position, Quaternion.identity);
                }
                else if (collision.gameObject.GetComponent<PlayerStats>().spownBoss)
                {
                    Instantiate(Boss, transform.position, Quaternion.identity);
                }
                else
                {
                    GetComponent<PlayerStats>().spownBoss = true;
                }
            }
        }
    }
}
