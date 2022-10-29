using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject targetBull;
    [SerializeField] double Range;
    public int damage { get; set; } = 5;
    bool isShot = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScanEnemy();
        Debug.Log(targetBull);
        if (targetBull != null)
        {
            //Debug.Log(targetBull.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, targetBull.transform.position, 0.02f);
        }
        else
        {
            Destroy(gameObject);
            Destroy(targetBull);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Enemy = collision.gameObject;
        if (Enemy.tag == "Enemy")
        {
            Destroy(gameObject);
            var attriBute = Enemy.GetComponent<EnemyAttribute>();
            attriBute.Shot(damage);
        }
    }

    public void updateTarget(GameObject target)
    {
        this.targetBull = target;
        Debug.Log(this.targetBull);
    }

    void ScanEnemy()
    {
        EnemyAttribute[] enemies = FindObjectsOfType<EnemyAttribute>();
        foreach (var enemy in enemies)
        {
            float targetDistance = Vector2.Distance(transform.position, enemy.transform.position);
            if (targetDistance <= Range)
            {
                targetBull = enemy.gameObject;
                break;
            }
        }
    }

}
