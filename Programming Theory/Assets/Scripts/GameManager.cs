using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager Instance {get; private set;}
    public bool isGameOver = false;

    void Awake()
    {
        if (Instance != null)
       {
           Destroy(gameObject);
           return;
       }

       Instance = this;
       DontDestroyOnLoad(gameObject);
    }
}
