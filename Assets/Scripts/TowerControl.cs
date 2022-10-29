using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    // Start is called before the first frame update
    [SerializeField] float timerShoot;
    [SerializeField] int Price;
    [SerializeField] double Range;
    float m_remainTime;
    bool isShot = false;
    void Start()
    {
        m_remainTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_remainTime -= Time.deltaTime;
        if (m_remainTime <= 0)
        {
            ScanEnemy();
        }
    }

    void SpawnBullet()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }

    void ScanEnemy()
    {
        EnemyAttribute[] enemies = FindObjectsOfType<EnemyAttribute>();
        foreach(var enemy in enemies)
        {
            float targetDistance = Vector2.Distance(transform.position, enemy.transform.position);
            
            if(targetDistance <= Range)
            {
                //Debug.Log(targetDistance);
                SpawnBullet();
                m_remainTime = timerShoot;
            }
        }
    }
}
