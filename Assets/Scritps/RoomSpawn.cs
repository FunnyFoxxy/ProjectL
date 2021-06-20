using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public enum Direction { Top, Bottom, Left, Right, None}
    public Vector2[] posInterior;
    public Direction direction;
    public GameObject[] variantsLoot;
    public GameObject[] interior;
    private RoomVariants variants;
    private int rand, countInterior;
    private bool spawned = false;
    float waitTime = 3f;

    private void Start()
    {
        countInterior = Random.Range(3, 10);
        posInterior = new Vector2[countInterior];
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.2f);
    }
    public void Spawn()
    {
        if (!spawned) // 1 up; 2 down; 3 left; 4 right
        {
            if (direction == Direction.Top)
            {
                rand = Random.Range(0, variants.topRooms.Length);
                Instantiate(variants.topRooms[rand], transform.position, Quaternion.identity);
                //Instantiate(variantsLoot[0], transform.position, Quaternion.identity);
                GenerateInerior();
                spawned = true;
            }
            else if (direction == Direction.Bottom)
            {
                rand = Random.Range(0, variants.bottomRooms.Length);
                Instantiate(variants.bottomRooms[rand], transform.position, Quaternion.identity);
                GenerateInerior();
                //Instantiate(variantsLoot[0], transform.position, Quaternion.identity);
                spawned = true;
                
            }
            else if (direction == Direction.Left)
            {
                rand = Random.Range(0, variants.leftRooms.Length);
                Instantiate(variants.leftRooms[rand], transform.position, Quaternion.identity);
                GenerateInerior();
                //Instantiate(variantsLoot[0], transform.position, Quaternion.identity);
                spawned = true;
                
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variants.rightRooms.Length);
                Instantiate(variants.rightRooms[rand], transform.position, Quaternion.identity);
                GenerateInerior();
                //Instantiate(variantsLoot[0], transform.position, Quaternion.identity);
                spawned = true;
            }
            else
            {
                spawned = true;
            }
           
        }

        
    }
    void GenerateInerior() //генерация интерьера
    {
        for (int i = 0; i < posInterior.Length - 1; i++)
        {
            posInterior[i] = GetPosition();
        }
        for (int i = 0; i < countInterior; i++)
        {
            rand = Random.Range(0, interior.Length - 1);
            if(posInterior[i].x == 0 && posInterior[i].y == 0)
            {
                continue;
            }
            Instantiate(interior[rand], posInterior[i], Quaternion.identity);
        }
    }
    Vector2 GetPosition() //создание точек спавнка для интерьера
    {
        Vector2 NewPositionInRoom = new Vector2();
        NewPos:
        NewPositionInRoom.x = transform.position.x + Random.Range(-1.25f, 1.25f);
        NewPositionInRoom.y = transform.position.y + Random.Range(-1.25f, 1.25f);
        foreach(Vector2 pos in posInterior)
        {
            if (pos != null)
            {
                if (pos.x - 0.45f >= NewPositionInRoom.x && pos.x + 0.45f <= NewPositionInRoom.x && pos.y + 0.45f <= NewPositionInRoom.y && pos.y - 0.45f >= NewPositionInRoom.y)
                {
                    goto NewPos;
                }
            }
        }
        return NewPositionInRoom;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RoomPoint") && collision.GetComponent<RoomSpawn>().spawned)
        {
            Destroy(gameObject);
        }
    }
   
}
