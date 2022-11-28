using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class RoadManager : MonoBehaviour
{
  public SplineComputer[] splineComputers;
  [SerializeField] CarMergeManager carMergeManager;
  int roadIndex;
  private void Awake()
  {
    ButtonsCostValue.addANewRoad += AddANewRoad;

    roadIndex = GameManager.Instance.addRoadButtonClicked;
    splineComputers[roadIndex].transform.parent.gameObject.SetActive(true);
    carMergeManager.ListCarsReferences();
  }


  private void OnDestroy()
  {
    ButtonsCostValue.addANewRoad -= AddANewRoad;
  }
  private void AddANewRoad()
  {
    roadIndex = GameManager.Instance.addRoadButtonClicked;

    for (int i = 0; i < splineComputers.Length; i++)
    {
      splineComputers[i].transform.parent.gameObject.SetActive(i == roadIndex);
    }
    carMergeManager.ListCarsReferences();
  }
}
