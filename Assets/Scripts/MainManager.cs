using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public bool isGameActive;
    public static MainManager instance;
    public VideoPlayer videoPlayer;
    

    void Start()
    {   
        isGameActive = false;
        videoPlayer = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
    }


    void Update()
    {

        if (videoPlayer !=null && videoPlayer.isPaused)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
}
