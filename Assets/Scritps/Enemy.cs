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

    public GameObject effectDeath;

    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void Update()
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
    public void DealDamage(float damage)//dealDeamage Player
    {
        healthBar.SetActive(true);
        healthBarSlader.value = CalculateHealPercentage();
        health -= damage;
        CheckDeath();
    }
    void HealCharacter(float heal) //heal
    {
        health += heal;
        CheckOverHeal();
        healthBarSlader.value = CalculateHealPercentage();
    }

    public virtual void CheckDeath() //Alave?
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(effectDeath, transform);
            Instantiate(LootDrop, transform.position, Quaternion.identity);
            //if (!dead)
            //{
                
            //    dead = true;
            //}
           
        }
    }
    private float CalculateHealPercentage() //lineheal
    {
        return (health / maxHealth);
    }
}
