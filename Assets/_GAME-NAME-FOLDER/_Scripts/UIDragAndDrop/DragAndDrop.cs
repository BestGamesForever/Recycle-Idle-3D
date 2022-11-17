using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler,IPointerDownHandler,IBeginDragHandler
{
    Vector3 StartPos;
    Quaternion StartRot;
    Vector3 StartSize;
    Vector3 _newsize;
    CanvasGroup _canvasGroup;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _newsize = new Vector3(.6f, .6f, .6f);
        StartPos = transform.localPosition;
        StartRot = transform.localRotation;
        StartSize = transform.localScale;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = _newsize;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        if (!ListContain.isDrop)
        {
            transform.localPosition = StartPos;
            transform.localRotation = StartRot;
            transform.localScale = StartSize;
        }       
    } 
    public void OnPointerDown(PointerEventData eventData)
    {
        ListContain.isDrop = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
    }
}
// public void OnDrop(PointerEventData eventData)
// {
//     RectTransform trans = transform as RectTransform;
//
//   // if (Vector2.Distance(ListContain._pointList[4].position, trans.position) <= 60)
//   // {
//   //     Debug.Log("Hey " + ListContain._pointList[4].name);
//   //     trans.position = ListContain._pointList[4].position;
//   //     trans.rotation = Quaternion.Euler(Vector3.zero);
//   //     trans.localScale = new Vector3(.6f, .4f, .3f);
//   // }
//   // else
//     {
//      //  transform.localPosition = StartPos;
//      //  transform.localRotation = StartRot;
//      //  transform.localScale = StartSize;
//      //  Debug.Log("Hey");
//     }
//
// }
