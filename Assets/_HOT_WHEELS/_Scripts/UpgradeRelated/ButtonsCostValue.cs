using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public enum Id
{
  first,
  second,
  third,
  fourth
}

public class ButtonsCostValue : MonoBehaviour
{
  public Id id;
  public AnimationCurve multiplier;
  public TextMeshProUGUI addCarCostText;
  public TextMeshProUGUI incomeCostText;
  public TextMeshProUGUI addRoadCostText;
  public TextMeshProUGUI mergeCostText;
  public TextMeshProUGUI totalMoneyText;
  float multiplierConst;

  public static bool isClicked;
  Button thisButton;
  public static event Action addANewRoad = delegate { };
  public static event Action addANewIncome = delegate { };

  void OnEnable()
  {
    thisButton = GetComponent<Button>();
    multiplierConst = 1.5f;
    addCarCostText.text = GameManager.Instance.newCarCost.ToString();
    incomeCostText.text = GameManager.Instance.incomeCots.ToString();
    addRoadCostText.text = GameManager.Instance.newRoadCost.ToString();
    mergeCostText.text = GameManager.Instance.mergeCost.ToString();
    isClicked = false;
  }

  public void ClickedMe()
  {

    int addCarButtonClicked = GameManager.Instance.addCarButtonClicked;
    int incomeButtonClicked = GameManager.Instance.incomeButtonClicked;
    int addRoadButtonClicked = GameManager.Instance.addRoadButtonClicked;
    int mergeButtonClicked = GameManager.Instance.mergeButtonClicked;

    int hearthUpgradeCost = GameManager.Instance.newCarCost;
    int incomeCots = GameManager.Instance.incomeCots;
    int speedCost = GameManager.Instance.newRoadCost;
    int mergeCost = GameManager.Instance.mergeCost;

    if (id == Id.first)
    {
      addCarButtonClicked++;
      GameManager.Instance.totalCoins -= hearthUpgradeCost;
      totalMoneyText.text = GameManager.Instance.totalCoins.ToString();

      hearthUpgradeCost += (int)(multiplier.Evaluate(addCarButtonClicked) * multiplierConst);
      addCarCostText.text = hearthUpgradeCost.ToString();
      GameManager.Instance.addCarButtonClicked = addCarButtonClicked;
      GameManager.Instance.newCarCost = (int)hearthUpgradeCost;
    }
    if (id == Id.second)
    {
      incomeButtonClicked++;
      GameManager.Instance.totalCoins -= incomeCots;
      totalMoneyText.text = GameManager.Instance.totalCoins.ToString();

      incomeCots += (int)(multiplier.Evaluate(incomeButtonClicked) * multiplierConst);
      incomeCostText.text = incomeCots.ToString();
      GameManager.Instance.incomeButtonClicked = incomeButtonClicked;
      GameManager.Instance.incomeCots = (int)incomeCots;

    }
    if (id == Id.third)
    {
      addRoadButtonClicked++;
      GameManager.Instance.totalCoins -= speedCost;
      totalMoneyText.text = GameManager.Instance.totalCoins.ToString();

      speedCost += (int)(multiplier.Evaluate(addRoadButtonClicked) * multiplierConst);
      addRoadCostText.text = speedCost.ToString();
      GameManager.Instance.addRoadButtonClicked = addRoadButtonClicked;
      GameManager.Instance.newRoadCost = (int)speedCost;
      addANewRoad?.Invoke();
    }
    if (id == Id.fourth)
    {
      mergeButtonClicked++;
      GameManager.Instance.totalCoins -= mergeCost;
      totalMoneyText.text = GameManager.Instance.totalCoins.ToString();

      mergeCost += (int)(multiplier.Evaluate(mergeButtonClicked) * multiplierConst);
      mergeCostText.text = mergeCost.ToString();
      GameManager.Instance.mergeButtonClicked = mergeButtonClicked;
      GameManager.Instance.mergeCost = (int)mergeCost;
    }
    EventManager.instance.OnButtonCheckFunc();
    addANewIncome?.Invoke();
  }
}
