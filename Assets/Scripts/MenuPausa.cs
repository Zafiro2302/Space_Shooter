using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPause;

    public void Resume()
    {
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }
    public void Menu(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Time.timeScale = 1f;
    }
   public void Exit()
    {
        Application.Quit();
    }
}
