using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    public GameObject gameOverUI;
    public GameObject roundCountGO;

    [Header("Wwise Events")]

    public AK.Wwise.Event ambienceStop;
    public AK.Wwise.Event gameOverSound;
    public AK.Wwise.Event gameOverMusic;
    public AK.Wwise.Event stopAll;
    public AK.Wwise.Event playMusicEvent;
    public AK.Wwise.Event stopMusicEvent;
    public string StopEvent = "default";


    void Start () {

        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
        }

        //playMusicEvent.Post(gameObject);
        gm.StartCoroutine (gm.PlayLevelMusic());
        
    }

    public IEnumerator GameOver ()
    {
        gameOverUI.SetActive(true);
        roundCountGO.SetActive(true);
        stopAll.Post(gameObject);
        yield return new WaitForSeconds(3);
    
    }

    public IEnumerator Restart ()
    {
        gameOverSound.Post(gameObject);
        ambienceStop.Stop(gameObject);
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(0);
    }

    public static void KillPlayer (PlayerHealth player) 
    {
        Destroy (player.gameObject);
        //DestroyEnemies("Enemy");
        AkSoundEngine.SetRTPCValue("GameOver", 0);
        gm.StartCoroutine (gm.GameOver());
        gm.StartCoroutine (gm.Restart());
        gm.StartCoroutine (gm.PlayStinger());
        Debug.Log("Should Respawn");
    }

     public IEnumerator PlayStinger ()
    {
        gameOverMusic.Post(gameObject);
        gameOverSound.Post(gameObject);
        ambienceStop.Stop(gameObject);
        stopMusicEvent.Stop(gameObject);
        yield return new WaitForSeconds(3);
    }


     public static void DestroyEnemies (string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in gameObjects)
        {
            Destroy (target);
        }
    }

    IEnumerator PlayLevelMusic()
    {
        yield return new WaitForSeconds(10);
        playMusicEvent.Post(gameObject);
        //yield return new WaitForSeconds(10);
    }

    public void StopAll()
    {
        stopAll.Post(gameObject);
    }


}
