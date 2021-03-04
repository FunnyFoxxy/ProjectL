using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public enum Direction { Top, Bottom, Left, Right, None}
    public Direction direction;
    public GameObject[] variantsLoot;
    private RoomVariants variants;
    private int rand;
    private bool spawned = false;
    float waitTime = 3f;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.4f);
    }
    public void Spawn()
    {
        if (!spawned) // 1 up; 2 down; 3 left; 4 right
        {
            if (direction == Direction.Top)
            {
                rand = Random.Range(0, variants.topRooms.Length);
                Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
                rand = Random.Range(0, variantsLoot.Length - 1);
                Instantiate(variantsLoot[rand], transform.position, variantsLoot[rand].transform.rotation);
            }
            else if (direction == Direction.Bottom)
            {
                rand = Random.Range(0, variants.bottomRooms.Length);
                Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);
                rand = Random.Range(0, variantsLoot.Length - 1);
                Instantiate(variantsLoot[rand], transform.position, variantsLoot[rand].transform.rotation);
            }
            else if (direction == Direction.Left)
            {
                rand = Random.Range(0, variants.leftRooms.Length);
                Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
                rand = Random.Range(0, variantsLoot.Length - 1);
                Instantiate(variantsLoot[rand], transform.position, variantsLoot[rand].transform.rotation);
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variants.rightRooms.Length);
                Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
                rand = Random.Range(0, variantsLoot.Length - 1);
                Instantiate(variantsLoot[rand], transform.position, variantsLoot[rand].transform.rotation);
            }
            //rand = Random.Range(0, variantsLoot.Length - 1);
            //Instantiate(variantsLoot[rand], transform.position, Quaternion.identity);
            spawned = true;

        }

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RoomPoint") && collision.GetComponent<RoomSpawn>().spawned)
        {
            Destroy(gameObject);
        }
    }
}
