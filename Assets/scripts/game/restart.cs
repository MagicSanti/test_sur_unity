using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class restart : MonoBehaviour
{
    public void RESTART()
    {
        string path = Application.persistentDataPath + "/save.json";
        File.Delete(path);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
