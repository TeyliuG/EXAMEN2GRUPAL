using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    private float minX, minY, maxX, maxY;
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private float timeEnemy;
    private float timeNextEnemy;

    private void Start()
    {
        maxX = points.Max(points => points.position.x);
        minX = points.Min(points => points.position.x);
        maxY = points.Max (points => points.position.y);
        minY = points.Min (points => points.position.y);
    }

    private void Update()
    {
        timeNextEnemy += Time.deltaTime;

        if (timeNextEnemy >= timeEnemy)
        {
            timeNextEnemy = 0;
            spawnEnemy();
        }

    }

    private void spawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemys.Length);

        Vector2 randompos = new Vector2(Random.Range(minX,maxX), Random.Range(minY, maxY));

        Instantiate(enemys[randomEnemy], randompos, Quaternion.identity);

    }
}
