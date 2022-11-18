using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutWhenStart : MonoBehaviour
{
    public Image fadeinoutImage;
    public Canvas UICanvas;
    void Start()
    {
        StartCoroutine(FadeInOut());
    }

     IEnumerator FadeInOut()
    {
        float elapsedtime = 0;
        float duration = 1f;
        Color startcolor = Color.black;
        Color endColor = Color.clear;       
      
        while (elapsedtime < duration)
        {
            elapsedtime += Time.deltaTime;
            fadeinoutImage.color = Color.Lerp(startcolor, endColor, elapsedtime / duration);
            yield return null;
        }
        UICanvas.sortingOrder = 0;
    }
}
