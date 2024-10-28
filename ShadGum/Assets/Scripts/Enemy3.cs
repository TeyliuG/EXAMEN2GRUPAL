using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float velocidad = 2f;
    public float rangoDeVision = 5f;
    public int vida = 100;
    public int daño = 10;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        MoverHaciaJugador();
    }

    void MoverHaciaJugador()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia < rangoDeVision)
        {
            Vector3 direccion = (player.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;

            if (distancia < 1f)
            {
                player.GetComponent<player>().RecibirDaño(daño);
            }
        }
    }

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}
