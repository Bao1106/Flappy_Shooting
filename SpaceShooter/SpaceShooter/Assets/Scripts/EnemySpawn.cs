using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float enemyRate = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("SpawnEnemy", enemyRate);

        //InvokeRepeating("IncreaseSpawnRate", 0f, 60f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject enemy = Instantiate(Enemy);
        enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        TimeSpawnNextEnemy();
    }

    void TimeSpawnNextEnemy()
    {
        float spawnRate;
        if(enemyRate > 1f)
        {
            spawnRate = Random.Range(1f, enemyRate);
        }
        else
        {
            spawnRate = 1f;
        }
        Invoke("SpawnEnemy", spawnRate);
    }

    void IncreaseSpawnRate()
    {
        if (enemyRate > 1f)
        {
            enemyRate--;
        }

        if(enemyRate == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    public void StartEnemySpawn()
    {
        enemyRate = 4f;
        Invoke("SpawnEnemy", enemyRate);
        InvokeRepeating("IncreaseSpawnRate", 0f, 60f);
    }

    public void StopEnemySpawn()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
