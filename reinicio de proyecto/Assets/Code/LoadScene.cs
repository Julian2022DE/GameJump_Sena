using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("Jesus");
    }

    public void Iniciar()
    {
        SceneManager.LoadScene("Jesus");
    }

    public void Salir()
    {

    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Jesus()
    {
        SceneManager.LoadScene("Jesus");
    }
}
