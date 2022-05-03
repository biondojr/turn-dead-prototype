using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool isTimerOn = false;
    public TextMeshProUGUI timerText;

    private bool isGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        isTimerOn = true;
        PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isTimerOn)
        {
            
            if(timeLeft > 0 )
            {
                timeLeft -= Time.unscaledDeltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                isTimerOn = false;
                ResumeGame();
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime);

        timerText.text = seconds + "s";
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
