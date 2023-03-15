using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject bar_;
    public int time;

    private void Start()
    {
        AnimatedBar();
    }
    public void AnimatedBar()
    {
        LeanTween.scaleX(bar_, 1, time).setOnComplete(ResetLVL);
    }
    void ResetLVL()
    {
        Debug.Log("Hola");
    }
}
