using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAlpha : MonoBehaviour
{
    [SerializeField] float alphaValue;

    [SerializeField] float fadeTime;

   [SerializeField] private bool fadeOut = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            StartCoroutine(FadeAlphaColor(alphaValue, fadeTime));
        }

        if (!fadeOut)
        {
            StartCoroutine(FadeAlphaColor(1.0f, fadeTime));
        }
    }


  public void SetFadeOut()
    {
        fadeOut = true;

    }



    IEnumerator FadeAlphaColor(float aValue , float time)
    {

        float alpha = GetComponent<Renderer>().material.color.a;


        
        for(float t =0.0f; t<1.0f;t += Time.deltaTime / time)
        {
            Color newColor = GetComponent<Renderer>().material.color;
               newColor.a = Mathf.Lerp(alpha, aValue, t);
            GetComponent<Renderer>().material.color = newColor;

            yield return null;
        }
    }


   public void ResetFadeOut()
    {
        fadeOut = false;
    }

    private void OnTriggerEnter(Collider collision)
    
        
    
    {
        if(collision.gameObject.tag == "FlashLight")
        {
            Debug.Log("In here");
            fadeOut = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "FlashLight")
        {
            fadeOut = false;
        }
    }
}
