using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TapTutorial : MonoBehaviour
{
  // Update is called once per frame
  public bool isDanger;
  public float speed;
  public int animSpeed;
  [SerializeField] private TextMeshProUGUI text;
  [SerializeField] private Canvas dangerCanvas;
  bool isAlert;
  bool isAlertPass;
  int amounttoSave;
  void OnEnable()
  {
    //EnemyFishesBehaviour.OnAlert += EnableText;
    //PuffPlayerInteractables.OnAlertPass += StartOneTime;
  }

  void OnDisable()
  {
    // EnemyFishesBehaviour.OnAlert -= EnableText;
  }
  private void EnableText()
  {
    isAlert = true;
    if (isAlert && !isAlertPass)
    {
      if (dangerCanvas != null)
      {
        dangerCanvas.enabled = true;
      }

      isAlertPass = true;
      amounttoSave = GameManager.Instance.tutorialTextToShown++;
      if (amounttoSave > 2)
      {
        return;
      }
      isDanger = true;
      TextMeshProUGUI tempText = text;
      if (tempText != null)
      {
        tempText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1080);
      }
      text.text = "RELEASE TO PUFF AND DODGE";
      text.fontSize = 50;
      GameObject go = transform.parent.gameObject;
      if (go != null)
      {
        go.SetActive(true);
      }
    }

    isAlert = false;
  }

  void StartOneTime()
  {
    if (dangerCanvas != null)
    {
      dangerCanvas.enabled = false;
    }
    isAlertPass = false;
  }
  void Update()
  {
    if (isDanger)
    {
      speed = .2f;
      transform.localScale = Vector3.one + (Vector3.one * Mathf.Sin(Time.time * animSpeed) * speed);
    }
    else
    {
      speed = .1f;
      transform.localScale = Vector3.one + (Vector3.one * Mathf.Sin(Time.time) * speed);
    }
  }
}
