using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

[SerializeField]
public class save
{
    [Header("Variables")]
    public int lvl;
    public Vector3 spawnpoint;
}
public class player_movement : MonoBehaviour
{
    [Header("Dependencies")]
    float rotationX;
    float rotationY;
    bool isGrounded;
    float speed;
    float NumberJumps=0f;
    private Rigidbody rb;
    [Header("variables changeables")]
    public float speedwalk=5f;
    public float MaxJumps=2f;
    public float jumpheight=500f;
    public float sensitivity=20f;
    [Header("Variables")]
    public save save=new save();
    Vector2 startPosition;
    Vector2 endPosition;
    // Start is called before the first frame update
    public void jump()
    {
        if (NumberJumps > MaxJumps - 1)
        {
            isGrounded = false;
        }
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpheight);
            NumberJumps += 1;           
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            Load();
        }
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            sensitivity *= 5;
        }
    }



    private void Load()
    {
        string path = Application.persistentDataPath + "/save.json";
        string json = File.ReadAllText(path);
        save = JsonUtility.FromJson<save>(json);
        transform.position = save.spawnpoint;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sensitivity = PlayerPrefs.GetFloat("sensibility");
        deplacements();
        rotation();
        GestionJump();
        run();
        death();
    }
    private void death()
    {
        if (transform.position.y <= -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed=speedwalk*2f;
        }
        else
        {
            speed = speedwalk;
        }
    }
    private void GestionJump()
    {
        if (NumberJumps > MaxJumps - 1)
        {
            isGrounded = false;
        }
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpheight);
                NumberJumps += 1;
            }
        }
    }
    private void deplacements()
    {
        float vertical=Input.GetAxis("Vertical")*Time.deltaTime*speed;
        float horizontal=Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        transform.Translate(horizontal, 0, vertical);
    }
    private void rotation()
    {
        Cursor.visible = true;
        //!isMouseOffScreen() pour limiter la souris a la fenetre !
        if (Input.GetMouseButton(1))
        {
            rotationX -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
            rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
            Cursor.visible = false;
            //limite de l'axe X
            if (rotationX < -90)
            {
                rotationX = -90;
            }
            if (rotationX > 90)
            {
                rotationX = 90;
            }
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }
    private bool isMouseOffScreen()
    {
        if (Input.mousePosition.x >= Screen.width - 2 || Input.mousePosition.x <= 2 || Input.mousePosition.y <= 2 ||  Input.mousePosition.y >= Screen.height - 2)
            return true;
        return false;
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        NumberJumps = 0;
    }

   
}
