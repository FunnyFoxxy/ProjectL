using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject block;

    private void OnTriggerStay2D(Collider2D collision) //Door Off
    {
        if (collision.CompareTag("Block"))
        {
            Instantiate(block, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.CompareTag("DoorLocation"))
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    
}
