using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuUI : MonoBehaviour
{
    public void StartButtonSandBox()
    {
        GameManager.Instance.isGameOver = false;
        SceneManager.LoadScene(1);
    }

    public void StartButtonArena()
    {
        GameManager.Instance.isGameOver = false;
        
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
