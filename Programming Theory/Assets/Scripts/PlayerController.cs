using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    private Rigidbody playerRb;
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float sprintMultiplier = 2;

    private float horizontal;
    private float vertical;
    private float mouseX;
    private float mouseY;
    private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("Main Camera");
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MainMovement();
        PlayerLook();
        
    }

    void MainMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * vertical * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontal * speed);

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
        }
    }

    void PlayerLook()
    {
        mouseX += cameraSensitivity * Input.GetAxis("Mouse X");
        mouseY -= cameraSensitivity * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        playerCamera.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
}
