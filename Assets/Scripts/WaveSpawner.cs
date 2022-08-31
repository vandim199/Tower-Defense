using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner waveSpawner{get; private set;}

    public GameObject spawnPosition;
    public float spawnRate = 1;
    public float waveDelay = 10;
    public Timer timer;
    public TMPro.TMP_Text waveTextbox;
    public List<GameObject> spawnQueue;
    public List<Wave> waves;

    private int currentWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(waveSpawner == null) waveSpawner = this;
        else Destroy(gameObject);

        StartCoroutine(newWave());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) AddToQueue();

        //if(spawnQueue.Count > 0) StartCoroutine(spawnDelay());
    }

    IEnumerator spawnDelay()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(spawnRate);

        if(spawnQueue.Count > 0) StartCoroutine(spawnDelay());
        else StartCoroutine(newWave());
    }

    IEnumerator newWave()
    {
        if(waves.Count > 0)
        {
            if(timer != null)
            {
                timer.gameObject.SetActive(true);
                timer.ResetBar(waveDelay);
            }

            yield return new WaitForSeconds(waveDelay);
            AddToQueue();
            currentWave++;
            waveTextbox.text = "Wave: " + currentWave;
            if(spawnQueue.Count > 0) StartCoroutine(spawnDelay());
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(spawnQueue[0], spawnPosition.transform);
        spawnQueue.RemoveAt(0);
    }

    public void AddToQueue()
    {
        foreach(Enemies enemies in waves[0].enemies)
        {
            for(int i = 0; i < enemies.count; i++)
            {
                spawnQueue.Add(enemies.GetEnemy());
            }
        }
        spawnRate = waves[0].spawnRate;
        waves.RemoveAt(0);
    }
}

[System.Serializable]
public class Wave
{
    public List<Enemies> enemies;
    public float spawnRate;
}

[System.Serializable]
public class Enemies
{
    public GameObject enemyPrefab;
    public GameObject rareEnemy;
    public int count;

    [Range(0, 100)]
    public float rareChance;

    public GameObject GetEnemy()
    {
        if(Random.Range(0, 100) < rareChance)
        {
            return rareEnemy;
        }
        return enemyPrefab;
    }
}
