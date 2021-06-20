using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenDoorScript : MonoBehaviour
{
    public GameObject text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerStats.playerStats.InActivePosition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerStats.playerStats.InActivePosition = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision) //Откритие двери
    {
        if (collision.tag == "Player" && PlayerStats.playerStats.KeyButtonPushed && PlayerStats.playerStats.imageKey.activeInHierarchy)
        {
            PlayerStats.playerStats.endLvl = true;
            Destroy(GameObject.Find("GameManager"));
            SceneManager.LoadScene(2);
            
        }
    }
}
