using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ListContain : MonoBehaviour,IDropHandler
{
    public static bool isDrop;
    public static int placedCounter;

    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag!=null)
        {
            isDrop = true;
            placedCounter++;
            eventData.pointerDrag.GetComponent<DragAndDrop>().enabled = false;
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition+new Vector2(0,50);
            if (placedCounter==5)
            {
                EventManager.instane.MovieStartFunc();
            }           
        }       
    }  
}
