using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int rutina;
    public float crono;
  //  public Animator anim;
    public Quaternion angulos;
    public float grados;

    public bool delay_Perder;


    public GameObject target;

    public string Scene;
    private void Start()
    {
      //  anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void comportamiento()
    {

        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
          //  anim.SetBool("Run", false);
            crono += 1 * Time.deltaTime;
            if (crono >= 2)
            {
                rutina = Random.Range(0, 2);
                crono = 0;
            }

            switch (rutina)
            {
                case 0:
                    // anim.SetBool("Walk", false);
                    break;

                case 1:
                    grados = Random.Range(0, 360);
                    angulos = Quaternion.Euler(0, grados, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulos, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                   // anim.SetBool("Walk", true);
                    break;

            }

        }
        else
        {
            var lookpos = target.transform.position - transform.position;
            lookpos.y = 0;
            var rotation = Quaternion.LookRotation(lookpos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            // anim.SetBool("Walk", false);



            // anim.SetBool("Run", true);
            transform.Translate(Vector3.forward * 4 * Time.deltaTime);
        }
    }

    private void Update()
    {
        comportamiento();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
             delay_Perder = true;
             Invoke("Delay_morir", 2f);      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        delay_Perder = false;
    }

    void Delay_morir()
    {
        if(delay_Perder == true)
        {
         SceneManager.LoadScene(Scene);
        }

    
    }
}
