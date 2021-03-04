using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlader;

    public GameObject LootDrop;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
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
    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        healthBarSlader.value = CalculateHealPercentage();
        health -= damage;
        CheckDeath();
    }
    void HealCharacter(float heal)
    {
        health += heal;
        CheckOverHeal();
        healthBarSlader.value = CalculateHealPercentage();
    }

    void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(LootDrop, transform.position, Quaternion.identity);
        }
    }
    private float CalculateHealPercentage()
    {
        return (health / maxHealth);
    }
}
