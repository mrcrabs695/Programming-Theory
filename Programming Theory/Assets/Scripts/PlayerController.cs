using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameObject playerCamera;
    [SerializeField] private List<GameObject> weapons;

    [SerializeField] private GameObject dummy;
    [SerializeField] private GameObject smartDummy;
    [SerializeField] private GameObject armedDummy;
    [SerializeField] private TextMeshProUGUI healthText;

    private Rigidbody playerRb;
    private float cameraSensitivity = 5;
    private float speed = 5;
    private float jumpForce = 5;
    private float sprintMultiplier = 2;
    public int health {get; private set;}

    private float horizontal;
    private float vertical;
    private float mouseX;
    private float mouseY;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        // sets camera and rigid body variables
        playerCamera = GameObject.Find("Main Camera");
        playerRb = GetComponent<Rigidbody>();
        health = 50;
        
    }

    // Update is called once per frame
    //! Stop forgetting to add new methods where they need to be called smh
    void LateUpdate()
    {
        if (!GameManager.Instance.isGameOver)
        {
        MainMovement();
        PlayerLook();
        WeaponSwitcher();
        DummyManualSpawn();
        }

        if (health <= 0)
        {
            GameManager.Instance.isGameOver = true;
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // basic ground check to prevent jumping midair
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        //? might make smart and armed dummy separate if statements so you can change each ones health
        if (collision.gameObject.CompareTag("Smart dummy") || collision.gameObject.CompareTag("Armed dummy"))
        {
            health -= 5;
            healthText.text = "Health: " + health;

            Debug.Log("Player health: " + health);
        }

        Debug.Log("Player collided with: " + collision.gameObject.name);
    }

    // i had to move this if statement to OnTriggerEnter as the bullet has a trigger collider
    private void OnTriggerEnter(Collider hit) 
    {
        if (hit.gameObject.CompareTag("Enemy Bullet"))
        {
            health -= 5;
            healthText.text = "Health: " + health;

            Debug.Log("Player health: " + health);
        }
    }

    void MainMovement()
    {
        // sets input variables to their specified input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // controls the forward backward and sideways motion
        transform.Translate(Vector3.forward * Time.deltaTime * vertical * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontal * speed);

        //? could be a better way to implement this
        if(Input.GetButtonDown("Sprint"))
        {
            speed *= sprintMultiplier;
        }

        if(Input.GetButtonUp("Sprint"))
        {
            speed /= sprintMultiplier;
        }

        if(isOnGround & Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (transform.position.y <= -50)
        {
            transform.position = new Vector3(0, 2, 0);
        }
    }

    void PlayerLook()
    {
        mouseX += cameraSensitivity * Input.GetAxis("Mouse X");
        mouseY -= cameraSensitivity * Input.GetAxis("Mouse Y");
        
        // this makes sure that the player does not snap their neck by preventing the camera from moving too far
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        playerCamera.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    void WeaponSwitcher()
    {
        //? again there is probably a better way to implement this but it works for now
        if (Input.GetKeyDown("1"))
        {
            bool active;
            active = weapons[0].activeSelf;
            active ^= true;
            
            weapons[0].SetActive(active);

            Debug.Log("Weapon switched, shotgun active: " + active);
            
        }
    }

    //? this will either be debug only or put in a sandbox like scene, like the current one
    void DummyManualSpawn()
    {
        Vector3 spawnPos = new Vector3(0, 2, 0);

        if (Input.GetKeyDown("b"))
        {
            Instantiate(dummy, spawnPos, dummy.transform.rotation);
        }

        if (Input.GetKeyDown("n"))
        {
            Instantiate(smartDummy, spawnPos, smartDummy.transform.rotation);
        }

        if (Input.GetKeyDown("m"))
        {
            Instantiate(armedDummy, spawnPos, armedDummy.transform.rotation);
        }

    }
}
