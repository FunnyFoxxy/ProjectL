using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMany : MonoBehaviour
{
    [SerializeField]
    private GameObject SettingsMeny;
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenSettings() {
        SettingsMeny.SetActive(true);
    }
    public void CloseSettings() {
        SettingsMeny.SetActive(false);
    }
    public void ExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
    
}
