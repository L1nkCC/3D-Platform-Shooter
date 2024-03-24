using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    ObstacleSpawner[] obstacleSpawners;

    [SerializeField]
    Score scoreOutput;

    [SerializeField]
    bool DEBUG = false;

    [SerializeField]
    [Tooltip("Defining a Quadratic Function for Wave number spawns in form f(x) = ax^2 + bx + c where x is the wave count starting at 0")]
    [Min(0)]
    float c_a, c_b;
    [SerializeField]
    [Tooltip("Defining a Quadratic Function for Wave number spawns in form f(x) = ax^2 + bx + c where x is the wave count starting at 0")]
    [Min(1)]
    float c_c;

    [SerializeField]
    [Tooltip("Defining a Exponential Decay Function for Obstacle spawn rate in form f(x) = a(1-r)^x + b where x is the wave count starting at 0")]
    [Min(.01f)]
    float r_a, r_b;
    [SerializeField]
    [Tooltip("Defining a Exponential Decay Function for Obstacle spawn rate in form f(x) = a(1-r)^x + b where x is the wave count starting at 0")]
    [Range(.01f,.999f)]
    float r_r;

    [SerializeField]
    float timeBetweenWaves;

    float spawnInterval;
    int spawnCount;
    int spawnDestroyedCount;

    int waveCount = 0;

    [SerializeField]
    UnityEvent OnRoundStart;

    public int score {  get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        obstacleSpawners = GetComponentsInChildren<ObstacleSpawner>();
        StartCoroutine(InitateWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && DEBUG)
        {
            Obstacle ob = obstacleSpawners[Random.Range(0, obstacleSpawners.Length)].Spawn();
            ob.onKill += OnObstacleKilled;
        }
    }

    IEnumerator InitateWave()
    {
        CalculateSpeedAndCount();
        yield return new WaitForSeconds(timeBetweenWaves);
        OnRoundStart?.Invoke();
        for (int i = 0; i < spawnCount; i++)
        {
            RandomSpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void CalculateSpeedAndCount()
    {
        spawnCount = Mathf.FloorToInt((c_a*(Mathf.Pow(waveCount,2)) + c_b*(Mathf.Pow(waveCount,1)) + c_c));
        spawnInterval = r_a * Mathf.Pow((1 - r_r),waveCount) + r_b;
    }

    void RandomSpawnObstacle()
    {
        Obstacle ob = obstacleSpawners[Random.Range(0, obstacleSpawners.Length)].Spawn();
        ob.onKill += OnObstacleKilled;
    }

    void OnObstacleKilled()
    {
        score++;
        scoreOutput.IncrementScore();
        spawnDestroyedCount++;

        if(spawnDestroyedCount >= spawnCount)
        {
            spawnDestroyedCount = 0;
            waveCount++;
            scoreOutput.IncrementRound();
            StartCoroutine(InitateWave());
        }

    }

}
