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
    public int gold;
    public int game;
    public float health;
    public float maxHealth;

   
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
}
