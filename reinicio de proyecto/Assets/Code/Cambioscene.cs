using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambioscene : MonoBehaviour
{
    // Start is called before the first frame update

    public string Scene;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(Scene);
    }
}
