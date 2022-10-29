using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    GameObject enemyPrefab;
    [SerializeField]
    GameObject[] enemyPrefabs;
    [SerializeField] GameObject bossPrefab;
    [SerializeField][Range(0, 50)] int poolSize = 10;
    [SerializeField][Range(0.1f, 30f)] float spawnTimer = 5f;
    float m_remainTime;
    int countOfEnemy;
    int countOfWay;
    GameObject[] pool;
    [SerializeField] int numOfEnemyInWay = 6;

    void Awake()
    {

    }

    private void Start()
    {
        m_remainTime = 0;
        countOfEnemy = 0;
        countOfWay = 0;
        SpawnEnemy();
    }

    private void Update()
    {
        m_remainTime -= Time.deltaTime;
        if (m_remainTime <= 0)
        {
            m_remainTime = spawnTimer;
            SpawnEnemy();
            
        }
    }

    void SpawnEnemy()
    {
        countOfEnemy++;
        if (countOfEnemy == numOfEnemyInWay)
        {
            SpawnBoss();
            m_remainTime = 15f;
            countOfEnemy = 0;
            return;
        }
        Vector3 pos = new Vector3(-11.5f, 2.5f);
        System.Random random = new System.Random();
        int idx = random.Next(0, enemyPrefabs.Length);
        enemyPrefab = enemyPrefabs[idx];
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
    void SpawnBoss()
    {
        countOfWay++;
        if (countOfWay % 5 !=0) return;
        Vector3 pos = new Vector3(-11.5f, 2.5f);
        Instantiate(bossPrefab, pos, Quaternion.identity);
    }
}
