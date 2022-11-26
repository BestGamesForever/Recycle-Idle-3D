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
  void Awake()
  {
    startPos = moneyImage.transform.position;
  }
  public void SpawnMoney()
  {
    DOTween.Kill(transform);

    moneyImage.transform.position = startPos;
    color = moneyImage.color;
    color.a = 255;
    moneyImage.color = color;
    moneyText.color = color;
    StartCoroutine(RemoveFromList());
  }

  IEnumerator RemoveFromList()
  {
    yield return null;
    transform.GetComponent<Collider>().enabled = false;
    moneyObj.SetActive(true);
    moneyImage.transform.DOMoveY((startPos.y + 50), .5f).OnComplete(() => transform.GetComponent<Collider>().enabled = true);
    moneyImage.DOFade(0, 1);
    moneyText.DOFade(0, 1);

  }
  public void DisableMoneyImage()
  {
    moneyObj.SetActive(false);
  }
}
