using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class BaseCarBehaviour : MonoBehaviour
{
  IEnumerator textColorChange = null;
  WaitForSeconds waitForSeconds;

  TextMeshProUGUI totalMoneyText;
  Transform icon;
  int totalMoney;
  public virtual void OnEnables()
  {
    Debug.Log($"totalMoney0  {totalMoney}");
    textColorChange = ColorChange();
    Debug.Log($"totalMoneyError  {totalMoney}");
    waitForSeconds = new WaitForSeconds(.25f);
    totalMoneyText = UIScript.onGetMoneyText();
    icon = UIScript.onGetMoneyIcon();
  }

  public virtual void GiveMoney(int amount)
  {
    Debug.Log($"totalMoney1  {totalMoney}");
    totalMoney = GameManager.Instance.totalCoins + amount;
    GameManager.Instance.totalCoins = totalMoney;
    EventManager.instance.OnButtonCheckFunc();
    StartCoroutine(textColorChange);

    EventManager.instance.ButtonAndCorrespondComponentAnim(null, icon, totalMoneyText.transform, transform);
  }

  IEnumerator ColorChange()
  {

    Debug.Log($"totalMoney2  {totalMoney}");
    totalMoneyText.text = totalMoney.ToString();
    totalMoneyText.color = Color.green;
    yield return waitForSeconds;
    totalMoneyText.color = Color.white;
    textColorChange = ColorChange();
  }
}
