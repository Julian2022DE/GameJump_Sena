using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private float maxSpeed = 5f;

    private void Start()
    {
        anim = this.anim.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        anim.SetFloat("Blend", rb.velocity.magnitude / maxSpeed);
    }
}
