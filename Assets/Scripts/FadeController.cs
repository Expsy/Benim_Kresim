using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;



public class FadeController : MonoBehaviour
{


    public Image blackImage;
    
    // Start is called before the first frame update
    void Start()
    {
        blackImage.canvasRenderer.SetAlpha(1f);
        
        FadeIn();
        
    }

    // Update is called once per frame
    public void FadeOut()
    {

        blackImage.CrossFadeAlpha(1,1,false);
    }

    public void FadeIn()
    {
        blackImage.CrossFadeAlpha(0,1,false);
    }

    public void FindFadeImage()
    {
        blackImage = GameObject.FindWithTag("FadeImage").GetComponent<Image>();
    }
}
