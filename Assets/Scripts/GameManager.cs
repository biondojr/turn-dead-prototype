using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button exitButton;
    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI timerText;
    private bool isGamePaused;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainManager.instance.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(isGamePaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
                isGamePaused = !isGamePaused;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        exitButton.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        exitButton.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        MainManager.instance.isGameActive = false;
        SceneManager.LoadScene("Main Menu");
    }
}
