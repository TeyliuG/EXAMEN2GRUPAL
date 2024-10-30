using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject closestEnemy;
    [SerializeField] private float rotationSpeed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        AimAtClosestEnemy();
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
}
