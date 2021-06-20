using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    //public GameObject[] walls;
    public GameObject wallEffects;
    public GameObject block;
    public GameObject door;

    [HideInInspector]public List<GameObject> enemies;
    //enemyes
    public GameObject[] enemyTypes;
    public Transform[] enemySpowner;
    public GameObject[] potions;
    private RoomVariants variants;
    private bool spawned;
    private bool wallDestroyed = false;
    bool clear = true;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        block.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) // Inter Treagger Player
    {

        if(collision.CompareTag("Player") && !spawned)
        {
            block.SetActive(true);
            foreach (Transform spowner in enemySpowner)
            {
                int rand = Random.Range(0, 10);
                if (rand < 6)
                {
                    GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length - 1)];
                    GameObject enemy = Instantiate(enemyType, spowner.position, Quaternion.identity);
                    enemy.transform.parent = transform;
                    enemies.Add(enemy);
                }
                else if(rand > 6)
                {
                    GameObject bonus = potions[Random.Range(0, potions.Length - 1)];
                    Instantiate(bonus, spowner.position, Quaternion.identity);
                }
            }
            spawned = true;
            clear = false;
            
        }
    }
    private void Update()
    {
        foreach (var enemy in enemies) // check on enemy
        {
            if (enemy == null)
                enemies.Remove(enemy);
        }
        if(enemies.Count == 0 && spawned)
        {
            block.SetActive(false);
        }
    }
  
    public void DestroyWalls() // destroy walls
    {
        
        block.SetActive(false);
        wallDestroyed = true;
    }
    
}
