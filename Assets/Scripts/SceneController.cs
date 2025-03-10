using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    [SerializeField] Vector2 spawnArea;

    // Current Wave
    private int wave;

    // Number of enemies in the wave
    [SerializeField] int spawnCount;

    // Number of enemies that can be spawned in at a given moment
    private int maxSpawnCount;

    private int curEnemiesCount;

    // Timer for the between wave break
    private CountDownTimer waveBreakTimer;

    private bool spawning;

    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        maxSpawnCount = 20;
        waveBreakTimer = GetComponent<CountDownTimer>();
        waveBreakTimer.duration = 15;
        waveBreakTimer.Begin();
        Messenger.AddListener(GameEvent.ENEMY_KILLED, () => { 
            curEnemiesCount--; 
            if (curEnemiesCount == 0) { waveBreakTimer.Begin(); }
        });
    }

    // Update is called once per frame
    void Update()
    {

        if (curEnemiesCount < maxSpawnCount && spawnCount > 0 && !waveBreakTimer.isCountingDown && !spawning)
        {
            spawning = true;
            Invoke("SpawnEnemy", UnityEngine.Random.Range(.25f, 3f));
        }

        // Timer functionality
        if (waveBreakTimer.timeRemaining == 0 && waveBreakTimer.isCountingDown)
        {
            OnBreakEnd();
        }
 
    }

    private void OnBreakEnd()
    {
        wave++;
        spawnCount = 5 + wave * UnityEngine.Random.Range(-2, 2);
        waveBreakTimer.isCountingDown = false;
    }

    private void SpawnEnemy()
    {
        GameObject enemy;
        enemy = Instantiate(prefab) as GameObject;
        ReactiveTarget target = enemy.GetComponent<ReactiveTarget>();
        target.maxHealth = 10 * Mathf.RoundToInt(Mathf.Pow((float)wave, 1.5f));
        target.health = target.maxHealth;
        target.SetScore(wave);
        float angle = UnityEngine.Random.Range(0, 360);
        enemy.transform.Rotate(0, angle, 0);
        enemy.transform.position = transform.position + new Vector3(UnityEngine.Random.Range(-spawnArea.x, spawnArea.x), 0, UnityEngine.Random.Range(-spawnArea.y, spawnArea.y));
        curEnemiesCount++;
        spawnCount--;
        Debug.Log("Enemy Spawned");
        spawning = false;
    }

}
