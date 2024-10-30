using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject closestEnemy;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform shootPoint;
    void Start()
    {

    }

    void Update()
    {
        FindClosestEnemy();
        AimAtClosestEnemy();
        if (Input.GetMouseButtonDown(0))
        {
            if (closestEnemy != null)
            {
                ShootAtEnemy();
            }
        }
    }
    private void AimAtClosestEnemy()
    {
        if (closestEnemy != null)
        {
            Vector3 directionToEnemy = closestEnemy.transform.position - playerTransform.position;
            float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    void ShootAtEnemy()
    {
        if (closestEnemy != null && BulletPrefab != null)
        {
            GameObject projectile = Instantiate(BulletPrefab, shootPoint.position, shootPoint.rotation);

            Vector2 direction = (closestEnemy.transform.position - shootPoint.position).normalized;

            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        }
    }
    private void FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(playerTransform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
        if (enemies.Length == 0)
        {
            closestEnemy = null;
        }
    }
}

