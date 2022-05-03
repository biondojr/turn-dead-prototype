using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject optionsScreen;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        MainManager.instance.isGameActive = true;
        SceneManager.LoadScene("Scene");

    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void ExitGame()
    {

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
        
    }
}
