using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectSkills : MonoBehaviour
{
  public static event Action spawnFirstCar = delegate { };
  public static event Action addANewRoad = delegate { };
  public int increaseIncomeAmount;
  public float increaseSpeedAmount;
  public Button[] uibuttons;
  public Image[] coolDownImages;
  public float[] coolDownSpeeds;


  public Button[] skillButtons; //0 mana 1 talent 2 speed
  public Transform[] correspondTransforms;
  public Transform[] currentAmountText;


  void Start()
  {
    EventManager.instance.OnButtonCheckFunc();
  }

  void OnEnable()
  {

  }

  public void SpawnANewCar()
  {
    spawnFirstCar?.Invoke();
    EventManager.instance.ButtonAndCorrespondComponentAnim(uibuttons[0].transform, null, correspondTransforms[0], currentAmountText[0]);
    StartCoroutine(StartCoolDown(coolDownImages[0], uibuttons[0], coolDownSpeeds[0]));
  }

  public void IncreaseIncome()
  {
    EventManager.instance.ButtonAndCorrespondComponentAnim(uibuttons[1].transform, null, correspondTransforms[1], currentAmountText[1]);
    var text = GameManager.Instance.IncomeIndexMultiplier += increaseIncomeAmount;
    StartCoroutine(StartCoolDown(coolDownImages[1], uibuttons[1], coolDownSpeeds[1]));
  }

  public void AddANewRoad()
  {
    addANewRoad?.Invoke();
    EventManager.instance.ButtonAndCorrespondComponentAnim(uibuttons[2].transform, null, correspondTransforms[2], currentAmountText[2]);
    StartCoroutine(StartCoolDown(coolDownImages[2], uibuttons[2], coolDownSpeeds[2]));
  }

  IEnumerator StartCoolDown(Image correspondImage, Button clickedButton, float duration)
  {
    float elapsedTimer = 0;
    float amount = 1;
    while (elapsedTimer < duration)
    {
      elapsedTimer += Time.deltaTime;
      amount = Mathf.Lerp(1, 0, elapsedTimer / duration);
      correspondImage.fillAmount = amount;
      clickedButton.interactable = false;
      correspondImage.enabled = true;
      yield return null;
    }
    clickedButton.interactable = true;
    correspondImage.enabled = false;
    correspondImage.fillAmount = 1;
    EventManager.instance.OnButtonCheckFunc();
  }
}
