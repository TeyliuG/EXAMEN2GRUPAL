using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private int maxHealth = 20;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        SceneManager.LoadScene("Derrota");
    }
}
