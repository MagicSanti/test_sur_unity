using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    private void Awake()
    {
        if(SceneManager.GetActiveScene().name != "paramètre")
        {
            if (!PlayerPrefs.HasKey("up") || !PlayerPrefs.HasKey("down") || !PlayerPrefs.HasKey("left") || !PlayerPrefs.HasKey("rigth") || !PlayerPrefs.HasKey("jump") || !PlayerPrefs.HasKey("run"))
            {
                SceneManager.LoadScene("paramètre");
            }
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("game");
    }
    public void Paramètre()
    {
        SceneManager.LoadScene("paramètre");
    }
    public void Menu()
    {
        if (PlayerPrefs.HasKey("up") || PlayerPrefs.HasKey("down") || PlayerPrefs.HasKey("left") || PlayerPrefs.HasKey("rigth") || PlayerPrefs.HasKey("jump") || PlayerPrefs.HasKey("run"))
        {
            SceneManager.LoadScene("menu");
        }
    }
}
