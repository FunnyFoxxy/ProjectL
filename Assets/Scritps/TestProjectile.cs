using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float timerStart;
    public float damage;
    public GameObject animationDesctoy;
    private void Update()
    {
        if(timerStart < 1) // время полута сниряда
        {
            timerStart += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision) //Попадание
    {
        var target = collision.GetComponent<Enemy>();

        if (collision.name != "Player")
        {
            if (target != null)
            {
                target.DealDamage(damage);
                Destroy(gameObject);
            }
            if (collision.tag == "Wall" || collision.tag == "Door" || collision.tag == "DoorLocation" || collision.tag == "Block")
            {
                DestroyThis();
            }
            
        }
        if(collision.isTrigger)
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        GameObject boom = Instantiate(animationDesctoy, transform.position, Quaternion.identity);
        Destroy(boom, 0.5f);
    }
}
