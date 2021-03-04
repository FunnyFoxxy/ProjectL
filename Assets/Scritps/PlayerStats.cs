using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats playerStats;
    public Text healthText;
    public Slider healthSlider;
    public GameObject player;
    public Text coinText;
    public Text soulText;
    public int coins;
    public int souls;
    public GameObject[] Subjects;
   
    public float health;
    public float maxHealth;

    public bool keyLocation;
    // Start is called before the first frame update

    private void Awake()
    {
        if (playerStats != null)
        {
            Destroy(this);
        }
        else 
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        health = maxHealth;
        SetHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
    }

    void CheckOverHeal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }


    void HealCharacter(float heal)
    {
        health += heal;
        CheckOverHeal();
        SetHealthUI();



    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        healthSlider.value = CalculateHealPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }
    void CheckDeath()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(player);
        }
    }
    private float CalculateHealPercentage()
    {
        return (health / maxHealth);
    }
    
    public void AddCurrency(CurrencyPickup currency)
    {
        if(currency.currentPickup == CurrencyPickup.PickupObject.COIN)
        {
            coins += currency.pickQuantity;
            coinText.text = this.coins.ToString();
        }
        else if(currency.currentPickup == CurrencyPickup.PickupObject.SOUL)
        {
            souls += currency.pickQuantity;
            soulText.text = this.souls.ToString();
        }
    }
}
