using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //public value
    public static PlayerStats playerStats;
    public Text healthText;
    public Slider healthSlider;
    public GameObject player;
    public Text coinText;
    public Text soulText;
    public Slider staminaSlider;
    public GameObject[] imagesHealth;
    public bool spownBoss;
    public GameObject imageKey;
    public GameObject wallEffect;
    public bool InActivePosition;
    public GameObject uiDeath;
    public int coins;
    public int souls;
    public GameObject[] Subjects;
   
    public float health;
    public float maxHealth;

    public bool KeyButtonPushed;
    public bool TriggerRoom;
    public bool endLvl;
    public float volume = 0.05f;
    //potions and effects
    public bool staminaPotion;
    public bool isAlave = true;
    // Start is called before the first frame update
        
    public List<AudioSource> sounttrecks;
    //local value
    AudioSource audioSource; //music in play
    float timer;
    public void OnKeyButtonDown()
    {
        KeyButtonPushed = !KeyButtonPushed;
    }
    private void Awake() //Start game
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
    void Start() //start programm 
    {
        if(endLvl)
        {
            Destroy(this);
        }
        //sounttrecks[0].Play();
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        SetHealthUI();
        int i = 0;
        foreach (var image in imagesHealth)
        {
            if(i < maxHealth)
            {
                image.SetActive(true);
            }
            else
            {
                image.SetActive(false);
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update() 
    {
        if(player == null)
        {
            if (health != 0)
            {
                if(GameObject.FindWithTag("PLayer") != null)
                player = GameObject.FindWithTag("PLayer");
            }
        }
        CheckDeath();
        if (staminaPotion == true) //Get Posion
        {
            timer += Time.deltaTime;
            if (timer <= 45) 
            {
                staminaSlider.value = staminaSlider.maxValue; 
            }
            else
            {
                timer = 0;
                staminaPotion = false;
            }
        }
        else
        {
            staminaSlider.value += 0.09f;
        }
    }

    void CheckOverHeal() //Check Healing
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }
    

    public void HealCharacter(float heal) // heal
    {
        health += heal;
        CheckOverHeal();
        SetHealthUI();
    }

    public void DealDamage(float damage) // if Get Damage
    {
        health -= damage;
        CheckDeath();
        SetHealthUI();
    }

    private void SetHealthUI() //For Interfase
    {
        //healthSlider.value = CalculateHealPercentage();
        //healthText.text = Mathf.Round(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        int i = 0;
        foreach (var image in imagesHealth)
        {
            if (i < health)
            {
                image.SetActive(true);
            }
            else
            {
                image.SetActive(false);
            }
            i++;
        }

    }
    void CheckDeath() //IM Alave? No
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(player, 1);
            audioSource.Stop();
            uiDeath.SetActive(true);
            if (isAlave)
            {
                sounttrecks[0].volume = volume;
                sounttrecks[0].Play();
                isAlave = false;
            }
            
            player.GetComponent<Animator>().SetTrigger("death");
        }
    }
    private float CalculateHealPercentage() //For Slader
    {
        return (Mathf.Round(health) / maxHealth);
    }
    
    public void AddCurrency(CurrencyPickup currency) // +Coin
    {
        if(currency.currentPickup == CurrencyPickup.PickupObject.COIN)
        {
            coins += currency.pickQuantity;
            coinText.text = this.coins.ToString();
        }
        //else if(currency.currentPickup == CurrencyPickup.PickupObject.SOUL)
        //{
        //    souls += currency.pickQuantity;
        //    soulText.text = this.souls.ToString();
        //}
    }
}
