using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    [SerializeField] Vector2 spawnArea;
    //[SerializeField] AudioSource hurtSound1;
    //[SerializeField] AudioSource hurtSound2;
    //[SerializeField] AudioSource hurtSound3;
    [SerializeField] GameObject player;
    [SerializeField] GameObject AmmoPickup;
    [SerializeField] GameObject HealthPickup;


    // Current Wave
    private int wave;

    // Number of enemies in the wave
    [SerializeField] int spawnCount;

    // Number of enemies that can be spawned in at a given moment
    private int maxSpawnCount;

    public int curEnemiesCount;

    // Timer for the between wave break
    private CountDownTimer waveBreakTimer;

    private bool spawning;

    private FirePistol playerGun;

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

        playerGun = player.GetComponentInChildren<FirePistol>();
        if (playerGun != null) { Debug.Log("Successfully got FirePistol"); }
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

        if (curEnemiesCount < 0)
            curEnemiesCount = 0;
 
    }

    private void OnBreakEnd()
    {
        wave++;
        curEnemiesCount = 0;
        spawnCount = 5 + wave + wave * UnityEngine.Random.Range(0, 2);
        waveBreakTimer.isCountingDown = false;
    }

    private void SpawnEnemy()
    {
        GameObject enemy;
        enemy = Instantiate(prefab) as GameObject;
        ZombieDeath target = enemy.GetComponent<ZombieDeath>();
        target.MaxEnemyHealth = 3 * Mathf.RoundToInt(Mathf.Pow((float)wave, 1.5f));
        if (UnityEngine.Random.Range(0, 9) == 9)
        {
            target.MaxEnemyHealth = 2 * target.MaxEnemyHealth;
        }
        target.EnemyHealth = target.MaxEnemyHealth;
        if (wave > 1)
            target.scoreValue = 50 * Mathf.RoundToInt(Mathf.Pow((float)wave, target.EnemyHealth / (10 + (wave - 1))));
        else
            target.scoreValue = 50;
        target.TheEnemy = enemy;
        ZombieAI ai = enemy.GetComponent<ZombieAI>();
        ai.thePlayer = player;
        ai.theEnemy = enemy;
        ai.enemySpeed = Mathf.Min(0.001f * (float)wave, 0.005f);
        ai.enemyDamage += UnityEngine.Random.Range(wave, 2 * wave);
        enemy.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        /*ai.hurtSound1 = hurtSound1;
        ai.hurtSound2 = hurtSound2;
        ai.hurtSound3 = hurtSound3;*/
        target.ammoBox = AmmoPickup;
        target.healthPack = HealthPickup;
        float angle = UnityEngine.Random.Range(0, 360);
        enemy.transform.Rotate(0, angle, 0);
        enemy.transform.position = transform.position + new Vector3(UnityEngine.Random.Range(-spawnArea.x, spawnArea.x), 0, UnityEngine.Random.Range(-spawnArea.y, spawnArea.y));
        curEnemiesCount++;
        spawnCount--;
        Debug.Log("Enemy Spawned");
        spawning = false;
    }

    public int GetWave()
    {
        return wave;
    }

}
