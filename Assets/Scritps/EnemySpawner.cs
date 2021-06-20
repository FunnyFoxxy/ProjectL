using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enimies;
    protected List<GameObject> allEnemy;
    public Sprite spownEfect;
    public float spownRate = 1;
    public int countSpown = 1;

    public void Spawn()
    {
        float x = Random.Range(this.transform.position.x - 2, this.transform.position.x + 2);
        float y = Random.Range(this.transform.position.y - 1, this.transform.position.y + 1);
        Vector2 spownPos = new Vector2(x, y);
        Instantiate(Enimies[0], spownPos, Quaternion.identity);
    }
    
}
