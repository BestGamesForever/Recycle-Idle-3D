using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectSkills : MonoBehaviour
{
  // public int increaseHearthAmount;
  public int increaseIncomeAmount;
  public float increaseSpeedAmount;
  public Button[] uibuttons;
  public Image[] coolDownImages;
  public float[] speeds;
  public TextMeshProUGUI hearthAmountText;
  public TextMeshProUGUI incomeAmountText;
  public TextMeshProUGUI speedAmountText;

  public Button[] skillButtons; //0 mana 1 talent 2 speed
  public Transform[] correspondTransforms;
  public Transform[] currentAmountText;


  void Start()
  {
    EventManager.instance.OnButtonCheckFunc();
  }

  void OnEnable()
  {
    hearthAmountText.text = GameManager.Instance.hearthAmount.ToString();
    incomeAmountText.text = GameManager.Instance.IncomeIndexMultiplier.ToString();
    speedAmountText.text = GameManager.Instance.SpeedAmount.ToString();
    speeds[0] = GameManager.Instance.hearthCooldownSpeed;
    speeds[1] = GameManager.Instance.talentCooldownSpeed;
    speeds[2] = GameManager.Instance.experienceCooldownSpeed;
  }

  public void IncreaseHearth()
  {
    EventManager.instance.ButtonAndCorrespondComponentAnim(uibuttons[0].transform, null, correspondTransforms[0], currentAmountText[0]);
    GameManager.Instance.hearthCooldownSpeed += 1;
    speeds[0] = GameManager.Instance.hearthCooldownSpeed;
    // GameManager.Instance.hearthAmount += increaseHearthAmount;
    hearthAmountText.text = GameManager.Instance.hearthAmount.ToString();
    StartCoroutine(StartCoolDown(coolDownImages[0], uibuttons[0], speeds[0]));
  }

  public void IncreaseIncome()
  {
    EventManager.instance.ButtonAndCorrespondComponentAnim(uibuttons[1].transform, null, correspondTransforms[1], currentAmountText[1]);
    //Cooldown
    GameManager.Instance.talentCooldownSpeed += 1;
    speeds[1] = GameManager.Instance.talentCooldownSpeed;
    var text = GameManager.Instance.IncomeIndexMultiplier += increaseIncomeAmount;
    incomeAmountText.text = GameManager.Instance.IncomeIndexMultiplier.ToString();
    GameManager.Instance.IncomeAmount = (int)(text * GameManager.Instance.SpeedAmount);
    //Function
    StartCoroutine(StartCoolDown(coolDownImages[1], uibuttons[1], speeds[1]));
  }

  public void IncreaseSpeed()
  {
    EventManager.instance.ButtonAndCorrespondComponentAnim(uibuttons[2].transform, null, correspondTransforms[2], currentAmountText[2]);
    GameManager.Instance.experienceCooldownSpeed += 1;
    speeds[2] = GameManager.Instance.experienceCooldownSpeed;
    GameManager.Instance.SpeedAmount += increaseSpeedAmount;
    speedAmountText.text = GameManager.Instance.SpeedAmount.ToString();
    var text = GameManager.Instance.IncomeIndexMultiplier;
    GameManager.Instance.IncomeAmount = (int)(text * GameManager.Instance.SpeedAmount);
    StartCoroutine(StartCoolDown(coolDownImages[2], uibuttons[2], speeds[2]));
  }

  IEnumerator StartCoolDown(Image correspondImage, Button clickedButton, float duration)
  {
    float elapsedTimer = 0;
    float amount = 1;
    while (elapsedTimer < .5f)
    {
      elapsedTimer += Time.deltaTime;
      amount = Mathf.Lerp(1, 0, elapsedTimer / duration);
      correspondImage.fillAmount = amount;
      clickedButton.interactable = false;
      // correspondImage.enabled = true;
      yield return null;
    }
    clickedButton.interactable = true;
    correspondImage.enabled = false;
    correspondImage.fillAmount = 1;
    EventManager.instance.OnButtonCheckFunc();
  }
}
