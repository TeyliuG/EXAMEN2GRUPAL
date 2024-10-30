using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [SerializeField] private int Damage = 20;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * Speed;
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy3 enemy = collision.GetComponent<Enemy3>();
            enemy.RecibirDaño(Damage);
            Destroy(gameObject);
        }
    }
    public void AddDamage()
    {
        Damage += 10;
    }
}
