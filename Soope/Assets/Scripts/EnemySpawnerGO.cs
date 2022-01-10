using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerGO : MonoBehaviour
{

    public GameObject EnemyGO;
    float maxSpawnRateinSeconds = 5f;
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateinSeconds);

        InvokeRepeating("IncreaseSpawn", 0f, 30f);
    }

    void SpawnEnemy()
    {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float SpawninNSeconds;

        if (maxSpawnRateinSeconds > 1f)
        {
            SpawninNSeconds = Random.Range(1f, maxSpawnRateinSeconds);
        }
        else
            SpawninNSeconds = 1f;

        Invoke("SpawnEnemy", SpawninNSeconds);
    }
    void IncreaseSpawn ()
    {
        if (maxSpawnRateinSeconds > 1f)
            maxSpawnRateinSeconds--;
        if (maxSpawnRateinSeconds == 1f)
            CancelInvoke("IncreaseSpawn");
    }

    public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRateinSeconds);

        InvokeRepeating("IncreaseSpawn", 0f, 30f);
    }
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("IncreaseSpawn");
        CancelInvoke("SpawnEnemy");
    }
    void Update()
    {
       
    }
}
