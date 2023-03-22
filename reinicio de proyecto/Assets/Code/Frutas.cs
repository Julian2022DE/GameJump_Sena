using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Frutas : MonoBehaviour
{
    public AudioClip Frutas_agarrar;
    private void OnTriggerEnter(Collider collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Frutas_agarrar, gameObject.transform.position);
            Destroy(this.gameObject);
        }
    }
}
