using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PutChildInList : MonoBehaviour
{
  //For Player Animations....
  public List<Image> showImageList;
  public List<TextMeshProUGUI> showTextist;
  Color32[] imageColor;
  Color32[] imageColorAlpha;


  void Awake()
  {
    Image[] childs = GetComponentsInChildren<Image>();
    foreach (Image item in childs)
    {
      showImageList.Add(item);

    }
    imageColor = new Color32[showImageList.Count];
    imageColorAlpha = new Color32[showImageList.Count];
    for (int i = 0; i < imageColor.Length; i++)
    {
      imageColor[i] = showImageList[i].color;
      imageColorAlpha[i] = imageColor[i];
      imageColorAlpha[i].a = 100;
    }
    TextMeshProUGUI[] textchilds = GetComponentsInChildren<TextMeshProUGUI>();
    foreach (TextMeshProUGUI item in textchilds)
    {
      showTextist.Add(item);
    }

  }
  public void AlphaOnandOff(bool isInteractable)
  {
    if (isInteractable)
    {
      for (int i = 0; i < showImageList.Count; i++)
      {
        showImageList[i].color = imageColor[i];
      }
      for (int i = 0; i < showTextist.Count; i++)
      {
        showTextist[i].color = new Color32(255, 255, 255, 255);
      }
    }
    else
    {
      for (int i = 0; i < showImageList.Count; i++)
      {
        showImageList[i].color = imageColorAlpha[i];
      }
      for (int i = 0; i < showTextist.Count; i++)
      {
        showTextist[i].color = new Color32(255, 255, 255, 100);
      }
    }
  }

}
