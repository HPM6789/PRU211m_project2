using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int Health;
    [SerializeField] public float Speed;
    [SerializeField] public int Reward;

    void Start()
    {
        Health = 10;
    }
    
    public void Shot(int damage)
    {
        Health -= damage;
        Debug.LogError("Shoot");
        if (Health <= 0) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
