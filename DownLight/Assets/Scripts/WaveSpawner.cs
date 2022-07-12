using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

     [System.Serializable]
     public class Wave
     {
         public string name;
         public Transform[] enemy;
         public int count;
         public float rate;
     }

    [Header("Wwise Events")]
     public AK.Wwise.Event waveChange;
     public AK.Wwise.Event spawn;
     public AK.Wwise.Event wallOpenSound;


     bool hasPlayed = false;

     

     public Wave[] waves;
     private int nextWave = 0;

     public Transform[] spawnPoints;

     public float timeBetweenWaves = 5f;
     private float waveCountdown;

     private float searchCountdown = 1f;

     public int currentRound = 0; //Rounds.
     public GameObject roundCount;
     public GameObject roundCountGO;

     public GameObject spawnEffect;

     public GameObject closedWall;
     public GameObject openWall;

     RoundCounter roundCounter;
     RoundCounter roundCounterGO;

     private void Awake ()
     {
         //round
       roundCounter = roundCount.GetComponent<RoundCounter>();
       roundCounterGO = roundCountGO.GetComponent<RoundCounter>();

     }


     private SpawnState state = SpawnState.COUNTING;

     void Start()
     {

         //round
         roundCounter.CurrentRoundText.text = currentRound.ToString();
         roundCounterGO.CurrentRoundText.text = currentRound.ToString();

           if (spawnPoints.Length == 0)
         {
             Debug.LogError("No spawn points referenced");
         }

         waveCountdown = timeBetweenWaves;
     }

     void Update ()
     {
         if (state == SpawnState.WAITING)
         {
             if (!EnemyIsAlive())
             {
                 WaveCompleted();
             }
             else
             {
                 return;
             }
         }

         if (waveCountdown <= 0)
         {
             if (state != SpawnState.SPAWNING)
             {
                 StartCoroutine(SpawnWave ( waves[nextWave] ) );
             }
         }
         else
         {
             waveCountdown -= Time.deltaTime;
         }

        // Test
        if (currentRound == 40 && !hasPlayed)
            {
                OpenWall();
                hasPlayed = true;
            }

     }

     void WaveCompleted () 
     {
         Debug.Log("Wave Completed");

         state = SpawnState.COUNTING;
         waveCountdown = timeBetweenWaves;

         if (nextWave + 1 > waves.Length - 1)
         {
             nextWave = 0;
             Debug.Log ("ALL WAVES COMPLETE! Looping...");
         }
         else
         {
             nextWave++;
         }  
     }
     

     bool EnemyIsAlive()
     {
         searchCountdown -= Time.deltaTime;
         if (searchCountdown <= 0f)
         {
             searchCountdown = 1f;
             if (GameObject.FindGameObjectWithTag("Enemy") == null)
             {
                 return false;
             }
         }

         return true;
     }

     IEnumerator SpawnWave(Wave _wave)
     {
         waveChange.Post(gameObject);
         currentRound = currentRound + 1;
         roundCounter.CurrentRoundText.text = currentRound.ToString();
         roundCounterGO.CurrentRoundText.text = currentRound.ToString();
         Debug.Log("Spawning Wave: " + _wave.name);
         state = SpawnState.SPAWNING;

         for (int i = 0; i < _wave.count; i++)
         {
             //SpawnEnemy (_wave.enemy);
             SpawnEnemy (_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
             yield return new WaitForSeconds( 1f/_wave.rate );
         }

         state = SpawnState.WAITING;

         yield break;
     }

     void SpawnEnemy (Transform _Enemy)
     {
         Debug.Log("Spawning Enemy");
         
         Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
         spawn.Post(gameObject);
         Instantiate (spawnEffect, _sp.position, _sp.rotation);
         Instantiate (_Enemy, _sp.position, _sp.rotation);
         //Instantiate (spawnEffect, _sp.position, _sp.rotation);
     }

     public void OpenWall()
     {
        Debug.Log("Door Open!");
        wallOpenSound.Post(gameObject);
        CinemachineShake.Instance.ShakeCamera(0.01f, 2.5f);
        closedWall.SetActive(false);
        openWall.SetActive(true);
     }
    
}
