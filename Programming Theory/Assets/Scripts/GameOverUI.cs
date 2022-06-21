using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject restartButton;
    
    
    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        if (GameManager.Instance.isGameOver)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartButton()
    {
        GameManager.Instance.isGameOver = false;
        SceneManager.LoadScene(0);
    }
}
