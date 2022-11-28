using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;
using System;

public class CarMergeManager : CarMergeManagerBase
{
  public SplineComputer[] splineComputers;
  public ButtonInteractableCheck MergeButtonCheck;
  public List<CarsLoopBehaviour> tempCars;
  public List<CarsLoopBehaviour> firstCarInTheList;
  public GameObject secondCarPrefab;
  public List<CarsLoopBehaviour> secondCarInTheList;
  public List<CarsLoopBehaviour> thirdCarInTheList;
  public List<CarsLoopBehaviour> fourthCarInTheList;
  public MergePositions mergePositions;
  int counter = 3;



  public void MergeFirstCarsButton()
  {
    if (firstCarInTheList.Count >= counter)
    {
      MergeCarsWhenThree(firstCarInTheList, tempCars, mergePositions, 0, secondCarPrefab, secondCarInTheList, 0);
      GameManager.Instance.secondCarListCount = secondCarInTheList.Count + 1;
      Debug.Log($"secondCar  {GameManager.Instance.secondCarListCount}");
      GameManager.Instance.firstCarListCount -= 3;
      MergeButtonCheck.CheckMergeButtonWhenReachThreeCars(secondCarInTheList.Count + 1);
    }
    if (firstCarInTheList.Count >= counter && firstCarInTheList.Count < counter)
    {

    }
  }
  public override void MergeCarsWhenThree(List<CarsLoopBehaviour> CarInTheList, List<CarsLoopBehaviour> tempCars, MergePositions mergePositions, int index, GameObject nextCar, List<CarsLoopBehaviour> newCar, int parentIndex)
  {
    base.MergeCarsWhenThree(CarInTheList, tempCars, mergePositions, index, nextCar, newCar, parentIndex);
  }

  public void ListCarsReferences()
  {
    int index = GameManager.Instance.addRoadButtonClicked;
    for (int i = 0; i < firstCarInTheList.Count; i++)
    {
      firstCarInTheList[i].GetComponent<SplineFollower>().spline = splineComputers[index];
    }
    for (int i = 0; i < secondCarInTheList.Count; i++)
    {
      secondCarInTheList[i].GetComponent<SplineFollower>().spline = splineComputers[index];
    }
    for (int i = 0; i < thirdCarInTheList.Count; i++)
    {
      thirdCarInTheList[i].GetComponent<SplineFollower>().spline = splineComputers[index];
    }
  }
}


