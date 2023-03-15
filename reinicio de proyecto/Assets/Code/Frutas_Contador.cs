using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Frutas_Contador : MonoBehaviour
{
    [SerializeField] private int Score_M;  
    [SerializeField] private int Score_C;
    [SerializeField] private int Score_W;
    [SerializeField] private int Money;

    public TextMeshProUGUI Manzanas;
    public TextMeshProUGUI Melon;
    public TextMeshProUGUI Cereza;
    public TextMeshProUGUI Money_;



    public GameObject Carnet_;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Score_M = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("Hola");
            Carnet_.SetActive(true);

        }
        if (Input.GetKeyUp("e")) 
        {
            Debug.Log("Bay");
            Carnet_.SetActive(false);

        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Manzana")
        {
            Score_M++;
            Manzanas.text = "" + Score_M;
           
            
        } 
        if (collision.gameObject.tag == "Melon")
        {
            Score_C++;
            Melon.text = "" + Score_C;        
            
        }
        if (collision.gameObject.tag == "Cereza")
        {
            Score_W++;
            Cereza.text = "" + Score_W;
          
        }

        // Dinero 

        if(collision.gameObject.tag == "Money")
        {

            //Manzana Money 

            while(Score_M > 0) 
            {
               Score_M--;
               Manzanas.text = "" + Score_M;

                if(Score_M >= 0)
                {
                    Money += 10;
                    Money_.text = "" + Money;
                }

                if(Score_M == 0)
                {
                    break;
                }
            }

            // Cereza Money

            while(Score_C > 0)
            {
               Score_C--;
               Cereza.text = "" + Score_C;

                if (Score_C <= 100)
                {
                    Money += 10;
                    Money_.text =  "" + Money;
                }

                if(Score_C == 0)
                {
                    break;
                }
            }

            // Melon Money

            while(Score_W > 0)
            {
                Score_W--;
                Melon.text = "" + Score_W;

                if (Score_W <= 100)
                {
                    Money += 10;
                    Money_.text = "" + Money;
                }
                if(Score_W == 0)
                {
                    break;
                }
            } 
        }
    }
}
