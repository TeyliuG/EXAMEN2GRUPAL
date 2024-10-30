using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosMejora : MonoBehaviour
{
    public int playerPoints = 100; 
    public int upgradeCost = 50;   
    public int upgradeLevel = 0;   
    public int maxUpgradeLevel = 5;

    public void PurchaseUpgrade()
    {
        if (playerPoints >= upgradeCost && upgradeLevel < maxUpgradeLevel)
        {
            playerPoints -= upgradeCost; 
            upgradeLevel++;              
            upgradeCost += 25;           

            Debug.Log("Compra realizada. Nivel de mejora: " + upgradeLevel + ", Puntos restantes: " + playerPoints);
        }
        else if (upgradeLevel >= maxUpgradeLevel)
        {
            Debug.Log("Has alcanzado el nivel máximo de mejora.");
        }
        else
        {
            Debug.Log("No tienes suficientes puntos para mejorar.");
        }
    }
}
