using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScripts : MonoBehaviour
{
    float time = 1;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        DealDamage();
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" && time >= 1)
        {
            DealDamage();
            time = 0;
        }
        time += Time.deltaTime;
        
    }
    private void DealDamage()
    {
        PlayerStats.playerStats.DealDamage(1);
    }
}
