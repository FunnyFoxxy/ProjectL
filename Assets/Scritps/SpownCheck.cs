using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("GNR"))
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (transform.position.x == 0 & transform.position.y == 0)
            Destroy(gameObject);
    }
}
