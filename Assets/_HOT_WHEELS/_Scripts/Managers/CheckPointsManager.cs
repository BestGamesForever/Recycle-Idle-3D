using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
  int addANewRoadPressed;
  int addIncomePressed;
  public ButtonInteractableCheck buttonCheck;
  void Start()
  {
    ButtonsCostValue.addANewIncome += CheckpointsActivate;
  }
  void OnDestroy()
  {
    ButtonsCostValue.addANewIncome -= CheckpointsActivate;
  }
  public void CheckpointsActivate()
  {
    addANewRoadPressed = GameManager.Instance.addRoadButtonClicked;
    addIncomePressed = GameManager.Instance.incomeButtonClicked;
    if (addIncomePressed == CheckPointsToFind.checkPointsAtStart.Count - 1)
    {
      CheckPointsToFind.isReachMax = true;
      Debug.Log($"GameObject  {gameObject}");
      buttonCheck.AddIncomeReachMax();
    }
    switch (addANewRoadPressed)
    {
      case 0:
        EnableThecheckPoints(addIncomePressed);
        break;
      case 1:
        EnableThecheckPoints(addIncomePressed);
        break;
      case 2:
        EnableThecheckPoints(addIncomePressed);
        break;
      default:
        break;
    }
  }
  void EnableThecheckPoints(int checkPointsLength)
  {
    for (int i = 0; i < CheckPointsToFind.checkPointsAtStart.Count; i++)
    {
      CheckPointsToFind.checkPointsAtStart[i].gameObject.SetActive(false);
    }
    for (int i = 0; i < checkPointsLength + 1; i++)
    {
      CheckPointsToFind.checkPointsAtStart[i].gameObject.SetActive(true);
    }
  }

}
