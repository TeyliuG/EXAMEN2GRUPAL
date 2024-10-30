using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieEnsangrentado : MonoBehaviour
{
    [SerializeField] private int HealthEnemy = 4;
    [SerializeField] private float SpeedEnemy = 3.0f;
    [SerializeField] private int DamageEnemy = 3;
    [SerializeField] private float AttackRateEnemy = 1.0f;
    [SerializeField] private int PointsEnemy = 10;
    public Player player;

    public Transform Follow;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        Seekingplayer();
    }
    private void Seekingplayer()
    {
        Vector2 direction = (Follow.position - transform.position);
        transform.position = Vector2.MoveTowards(transform.position, Follow.position, SpeedEnemy * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(DamageEnemy);
        }
    }
    private void Die()
    {
        if (HealthEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
