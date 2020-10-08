using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    //Array of various SpawnPoints, Enemy, RandomEnemy
    public Transform[] SpawnPoints;
    public GameObject[] Enemy;
    int randomSpawnPoint, RandomEnemy;

    // Allows us to instantiate a Enemy only if Player is alive
    public static bool SpawnAllowed;

    // Use this for initialization
    void Start()
    {
        // here we start to instantiate enemy every 1 second by invoking SpawnAEnemy method
        SpawnAllowed = true;
        InvokeRepeating("SpawnAEnemy", 0f, 1f);

    }

    // Update is called once per frame
    void SpawnAEnemy()
    {  // here is spawn is allowed
        if (SpawnAllowed)
        {  // then randomSpawnPoint is calculated from 0 to SpawnPoint array length
            randomSpawnPoint = Random.Range(0, SpawnPoints.Length);
            // RandomEnemy is calculated from 0 to Enemy array length 
            RandomEnemy = Random.Range(0, Enemy.Length);
            // then new random Enemy is Spawned in random spawnPoints 
            Instantiate(Enemy[RandomEnemy], SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
