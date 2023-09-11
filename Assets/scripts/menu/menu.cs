using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    private void Awake()
    {
        if(SceneManager.GetActiveScene().name != "param�tre")
        {
            if (!PlayerPrefs.HasKey("up") || !PlayerPrefs.HasKey("down") || !PlayerPrefs.HasKey("left") || !PlayerPrefs.HasKey("rigth") || !PlayerPrefs.HasKey("jump") || !PlayerPrefs.HasKey("run"))
            {
                SceneManager.LoadScene("param�tre");
            }
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("game");
    }
    public void Param�tre()
    {
        SceneManager.LoadScene("param�tre");
    }
    public void Menu()
    {
        if (PlayerPrefs.HasKey("up") || PlayerPrefs.HasKey("down") || PlayerPrefs.HasKey("left") || PlayerPrefs.HasKey("rigth") || PlayerPrefs.HasKey("jump") || PlayerPrefs.HasKey("run"))
        {
            SceneManager.LoadScene("menu");
        }
    }
}
