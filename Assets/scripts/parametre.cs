using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class parametre : MonoBehaviour
{
    public Slider sensibility;
    // Start is called before the first frame update
    void Start()
    {
        sensibility.value = (PlayerPrefs.GetFloat("sensibility") - 100) / 1000;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("sensibility", 100+sensibility.value*1000);
    }
}
