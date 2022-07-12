using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject playMenuUI;
    public GameObject settingsMenuUI;
     public static bool GameIsPaused = false;

     public AK.Wwise.Event pauseMusicEvent;
     public AK.Wwise.Event resumeMusicEvent;

    // Update is called once per frame

    void Start()
    {
        GameIsPaused = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

   public void Resume()
    {
        resumeMusicEvent.Post(gameObject);
        //AkSoundEngine.SetRTPCValue("GameOver", 10);
        AkSoundEngine.SetRTPCValue("SFXVolume", 100);
        pauseMenuUI.SetActive(false);
        playMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMusicEvent.Post(gameObject);
        //AkSoundEngine.SetRTPCValue("GameOver", 0);
        AkSoundEngine.SetRTPCValue("SFXVolume", 0);
        pauseMenuUI.SetActive(true);
        playMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game!");
        Application.Quit();
    }

}
