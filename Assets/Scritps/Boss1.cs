using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    Animator animator;
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlader;

    public GameObject LootDrop;

    private void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }
    void CheckDeath() //is Alave?
    {
        if (health <= 0)
        {
            animator.SetTrigger("Death");
            //animator.Play("Death");
            Destroy(gameObject, 2);
            Instantiate(LootDrop, transform.position, Quaternion.identity);
        }
    }
    
    
    public void Update()
    {
        CheckDeath();
    }

    void CheckOverHeal()// need heal?
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }


    }
    public void DealDamage(float damage)//deal damage
    {
        healthBar.SetActive(true);
        healthBarSlader.value = CalculateHealPercentage();
        health -= damage;
        CheckDeath();
    }
    void HealCharacter(float heal)//heal
    {
        health += heal;
        CheckOverHeal();
        healthBarSlader.value = CalculateHealPercentage();
    }

   
    private float CalculateHealPercentage()//line heal
    {
        return (health / maxHealth);
    }

}
