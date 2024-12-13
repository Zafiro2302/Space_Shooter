using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinJuego : MonoBehaviour
{
    public void Reinicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void exit()
    {
        Application.Quit();
    }
}
