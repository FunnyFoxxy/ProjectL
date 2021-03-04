using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLootScreept : EnemySpawner
{
    public GameObject[] loot;
    bool spowned;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!spowned && collision.tag == "Player")
        {
            for (int i = 0; i < countSpown; i++)
            {
                Spawn();
            }
            spowned = true;
            Destroy(GetComponent<Collider2D>());
            StartCoroutine("FixedUpdate");
           
        }    
    }
    private void FixedUpdate()
    {
        var enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (spowned == true && enemy == 0)
        {
            foreach (var item in loot)
            {
                int rnd = Random.Range(-5, 10);
                if (rnd < 0)
                { 
                    rnd = 0;
                }
                for (int i = 1; i < rnd; i++)
                {
                    float x = Random.Range(this.transform.position.x - 0.05f, this.transform.position.x + 0.05f);
                    float y = Random.Range(this.transform.position.y - 0.05f, this.transform.position.y + 0.05f);
                    Vector2 spownPos = new Vector2(x, y);
                    Instantiate(item, spownPos, Quaternion.identity);
                }
            }
            Destroy(gameObject);
        }
    }

}   
