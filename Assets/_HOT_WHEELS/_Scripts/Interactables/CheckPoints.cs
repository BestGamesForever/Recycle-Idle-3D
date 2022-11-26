using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class CheckPoints : MonoBehaviour, ICheckPoints
{
  public GameObject moneyObj;
  public Image moneyImage;
  public TextMeshProUGUI moneyText;
  Vector3 startPos;
  Color32 color;
  Tween dotWeen;
  IEnumerator RemoveFromLists;
  void Awake()
  {
    startPos = moneyImage.transform.position;
    RemoveFromLists = RemoveFromList();
  }
  public void SpawnMoney()
  {

    dotWeen.Complete();
    dotWeen.Kill();
    StopCoroutine(RemoveFromLists);
    RemoveFromLists = RemoveFromList();
    moneyImage.transform.position = startPos;
    moneyImage.color = new Color32(255, 255, 255, 255);
    moneyText.color = new Color32(255, 255, 255, 255);
    StartCoroutine(RemoveFromLists);
  }

  IEnumerator RemoveFromList()
  {
    yield return null;
    transform.GetComponent<Collider>().enabled = false;
    moneyObj.SetActive(true);
    moneyImage.DOFade(1, .01f);
    moneyText.DOFade(1, .01f);
    dotWeen = moneyImage.transform.DOMoveY((startPos.y + 50), .5f).OnComplete(() => transform.GetComponent<Collider>().enabled = true);
    dotWeen = moneyImage.DOFade(0, 1f);
    dotWeen = moneyText.DOFade(0, 1f);

  }
  public void DisableMoneyImage()
  {
    moneyObj.SetActive(false);
  }
}
