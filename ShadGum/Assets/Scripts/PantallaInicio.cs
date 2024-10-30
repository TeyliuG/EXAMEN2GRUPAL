using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaInicio : MonoBehaviour
{
    [SerializeField] private string nombreEscena = "NombreDeLaEscena";

    public void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
