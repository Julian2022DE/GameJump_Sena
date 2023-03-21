using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DentedPixel;

public class Bar : MonoBehaviour
{
    public GameObject bar_;
    public int time;
    public string Scene;

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
        SceneManager.LoadScene(Scene);
    }
}
