using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum Id
{
  first,
  second,
  third
}

public class ButtonsCostValue : MonoBehaviour
{
  public Id id;
  public int costValue;
  public AnimationCurve multiplier;
  public TextMeshProUGUI hearthCostText;
  public TextMeshProUGUI incomeCostText;
  public TextMeshProUGUI speedCostText;
  public TextMeshProUGUI totalMoneyText;
  float multiplierConst;

  public static bool isClicked;

  int hearthValue;
  int incomeValue;
  int speedValue;
  Button thisButton;

  int totalMoney;

  void OnEnable()
  {
    thisButton = GetComponent<Button>();
    multiplierConst = 1.5f;
    hearthCostText.text = GameManager.Instance.hearthUpgradeCost.ToString();
    incomeCostText.text = GameManager.Instance.incomeCots.ToString();
    speedCostText.text = GameManager.Instance.speedCost.ToString();
    isClicked = false;
  }

  public void ClickedMe()
  {

    int hearthButtonClicked = GameManager.Instance.hearthButtonClicked;
    int incomeButtonClicked = GameManager.Instance.incomeButtonClicked;
    int speedButtonClicked = GameManager.Instance.speedButtonClicked;

    int hearthUpgradeCost = GameManager.Instance.hearthUpgradeCost;
    int incomeCots = GameManager.Instance.incomeCots;
    int speedCost = GameManager.Instance.speedCost;

    if (id == Id.first)
    {
      hearthButtonClicked++;
      GameManager.Instance.totalCoins -= hearthUpgradeCost;
      totalMoneyText.text = GameManager.Instance.totalCoins.ToString();
      Debug.Log("Cost" + speedCost);
      Debug.Log("GameManager.Instance.totalCoins " + GameManager.Instance.totalCoins);
      hearthUpgradeCost += (int)(multiplier.Evaluate(hearthButtonClicked) * multiplierConst);
      hearthCostText.text = hearthUpgradeCost.ToString();
      GameManager.Instance.hearthButtonClicked = hearthButtonClicked;
      GameManager.Instance.hearthUpgradeCost = (int)hearthUpgradeCost;
    }
    if (id == Id.second)
    {
      incomeButtonClicked++;
      GameManager.Instance.totalCoins -= incomeCots;
      totalMoneyText.text = GameManager.Instance.totalCoins.ToString();
      Debug.Log("Cost" + speedCost);
      Debug.Log("GameManager.Instance.totalCoins " + GameManager.Instance.totalCoins);
      incomeCots += (int)(multiplier.Evaluate(incomeButtonClicked) * multiplierConst);
      incomeCostText.text = incomeCots.ToString();
      GameManager.Instance.incomeButtonClicked = incomeButtonClicked;
      GameManager.Instance.incomeCots = (int)incomeCots;
    }
    if (id == Id.third)
    {
      speedButtonClicked++;
      GameManager.Instance.totalCoins -= speedCost;
      totalMoneyText.text = GameManager.Instance.totalCoins.ToString();
      Debug.Log("Cost" + speedCost);
      Debug.Log("GameManager.Instance.totalCoins " + GameManager.Instance.totalCoins);
      speedCost += (int)(multiplier.Evaluate(speedButtonClicked) * multiplierConst);
      speedCostText.text = speedCost.ToString();
      GameManager.Instance.speedButtonClicked = speedButtonClicked;
      GameManager.Instance.speedCost = (int)speedCost;
    }
    EventManager.instance.OnButtonCheckFunc();
  }
}
