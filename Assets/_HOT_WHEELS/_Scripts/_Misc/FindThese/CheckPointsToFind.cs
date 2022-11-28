using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsToFind : MonoBehaviour
{
  public static List<CheckPoints> checkPointsAtStart;
  public static bool isReachMax;
  int addANewRoadPressed;
  int addIncomePressed;
  void Start()
  {
    addANewRoadPressed = GameManager.Instance.addRoadButtonClicked;
    addIncomePressed = GameManager.Instance.incomeButtonClicked;
    isReachMax = false;
    checkPointsAtStart = new List<CheckPoints>();
    if (gameObject.activeInHierarchy)
    {
      CheckPoints[] checkPointsAtStarts = GetComponentsInChildren<CheckPoints>();
      for (int i = 0; i < checkPointsAtStarts.Length; i++)
      {
        checkPointsAtStart.Add(checkPointsAtStarts[i]);
      }
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

    for (int i = 0; i < checkPointsAtStart.Count; i++)
    {
      checkPointsAtStart[i].gameObject.SetActive(false);
    }
    for (int i = 0; i < checkPointsLength + 1; i++)
    {
      checkPointsAtStart[i].gameObject.SetActive(true);
    }
  }
}
