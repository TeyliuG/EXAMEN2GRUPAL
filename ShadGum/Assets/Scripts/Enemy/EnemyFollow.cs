using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    public float rotationSpeed = 5f;
    [SerializeField] private float enemySpeed = 10f;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {

        MoveTowardsPlayer();

    }
    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
        Vector2 direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
