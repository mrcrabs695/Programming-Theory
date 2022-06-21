using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject playerCamera;
    [SerializeField] private List<GameObject> weapons;

    [SerializeField] private GameObject dummy;
    [SerializeField] private GameObject smartDummy;
    [SerializeField] private GameObject armedDummy;

    private Rigidbody playerRb;
    private float cameraSensitivity = 5;
    private float speed = 5;
    private float jumpForce = 5;
    private float sprintMultiplier = 2;

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
        
    }

    // Update is called once per frame
    //! Stop forgetting to add new methods where they need to be called smh
    void LateUpdate()
    {
        MainMovement();
        PlayerLook();
        WeaponSwitcher();
        DummyManualSpawn();
        
    }

    // basic ground check to prevent jumping midair
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
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
