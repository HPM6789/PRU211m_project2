using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Start is called before the first frame update
    List<Tuple<double, double>> paths;
    GameObject target;
    int curIdx;

    void Start()
    {
        target = new GameObject();
        paths = new List<Tuple<double, double>>
        {
            new Tuple<double, double>(-11.5,2.5),
            new Tuple<double, double>(-10.5,2.5),
            new Tuple<double, double>(-9.5,2.5),
            new Tuple<double, double>(-9.5,1.5),
            new Tuple<double, double>(-8.5,1.5),
            new Tuple<double, double>(-7.5,1.5),
            new Tuple<double, double>(-6.5,1.5),
            new Tuple<double, double>(-5.5,1.5),
            new Tuple<double, double>(-5.5,0.5),
            new Tuple<double, double>(-5.5,-1.5),
            new Tuple<double, double>(-5.5,-2.5),
            new Tuple<double, double>(-4.5,-2.5),
            new Tuple<double, double>(-3.5,-2.5),
            new Tuple<double, double>(-2.5,-2.5),
            new Tuple<double, double>(-2.5,-1.5),
            new Tuple<double, double>(-2.5,-0.5),
            new Tuple<double, double>(-2.5,0.5),
            new Tuple<double, double>(-2.5,1.5),
            new Tuple<double, double>(-2.5,2.5),
            new Tuple<double, double>(-2.5,3.5),
            new Tuple<double, double>(-1.5,3.5),
            new Tuple<double, double>(-0.5,3.5),
            new Tuple<double, double>(0.5,3.5),
            new Tuple<double, double>(1.5,3.5),
            new Tuple<double, double>(2.5,3.5),
            new Tuple<double, double>(2.5,2.5),
            new Tuple<double, double>(2.5,1.5),
            new Tuple<double, double>(2.5,0.5),
            new Tuple<double, double>(2.5,-0.5),
            new Tuple<double, double>(2.5,-1.5),
            new Tuple<double, double>(2.5,-2.5),
            new Tuple<double, double>(2.5,-3.5),
            new Tuple<double, double>(3.5,-3.5),
            new Tuple<double, double>(4.5,-3.5),
            new Tuple<double, double>(5.5,-3.5),
            new Tuple<double, double>(6.5,-3.5),
            new Tuple<double, double>(7.5,-3.5),
            new Tuple<double, double>(8.5,-3.5),
            new Tuple<double, double>(8.5,-2.5),
            new Tuple<double, double>(8.5,-1.5),
            new Tuple<double, double>(9.5,-1.5),
            new Tuple<double, double>(10.5,-1.5),
            new Tuple<double, double>(11.5,-1.5),
        };
        curIdx = 0;
        var x = new Vector3((float)paths[0].Item1, (float)paths[0].Item2);
        target.transform.position = x;
        Moving();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == target.transform.position.x && transform.position.y == target.transform.position.y)
        {
            curIdx++;
            if (curIdx == paths.Count)
            {
                Destroy(gameObject);
                Destroy(target.gameObject);
                return;
            }
            var x = new Vector3((float)paths[curIdx].Item1, (float)paths[curIdx].Item2);
            target.transform.position = x;
        }
        Moving();
    }
    void Moving()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 0.0025f);
    }
    private void OnDestroy()
    {
        Destroy(target.gameObject);
    }
}
