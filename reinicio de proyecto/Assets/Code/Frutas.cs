using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Frutas : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)

    {
        if (collision.gameObject.tag == "Player")
        {
                Destroy(this.gameObject);
        }
    }
}
