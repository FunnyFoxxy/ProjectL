using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickup : MonoBehaviour
{
    public enum PickupObject { COIN, SOUL};
    public PickupObject currentPickup;
    public int pickQuantity;

    private void OnTriggerEnter2D(Collider2D collision)  //get coin
    {
        if (collision.name == "Player")
        {
            PlayerStats.playerStats.AddCurrency(this);
            Destroy(gameObject);
        }
        
    }

  
}
