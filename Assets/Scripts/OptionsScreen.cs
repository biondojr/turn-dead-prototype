using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{
    public Toggle fullscreen, vsync;
    void Start()
    {
        fullscreen.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount ==0)
        {
            vsync.isOn = false;
        }
        else
        {
            vsync.isOn = true;
        }
    }

    public void ApllyChanges()
    {
        Screen.fullScreen = fullscreen.isOn;

        if(vsync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }   
    
}
