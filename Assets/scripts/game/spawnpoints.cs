using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class spawnpoints : MonoBehaviour
{
    public int lvl;
    public Vector3 SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (lvl > collision.gameObject.GetComponent<player_movement>().save.lvl)
        {
            collision.gameObject.GetComponent<player_movement>().save.spawnpoint = SpawnPoint;
            collision.gameObject.GetComponent<player_movement>().save.lvl = lvl;
            string json = JsonUtility.ToJson(collision.gameObject.GetComponent<player_movement>().save);
            string path = Application.persistentDataPath+"/save.json";
            File.WriteAllText(path, json);
        }
    }
}
