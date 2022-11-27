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
  private void Start()
  {
    SelectSkills.addANewRoad += AddANewRoad;
  }


  private void OnDestroy()
  {
    SelectSkills.addANewRoad -= AddANewRoad;
  }
  private void AddANewRoad()
  {
    splineComputers[0].transform.parent.gameObject.SetActive(false);
    splineComputers[1].transform.parent.gameObject.SetActive(true);
    for (int i = 0; i < firstCarInTheList.Count; i++)
    {
      firstCarInTheList[i].GetComponent<SplineFollower>().spline = splineComputers[1];
    }
    for (int i = 0; i < secondCarInTheList.Count; i++)
    {
      secondCarInTheList[i].GetComponent<SplineFollower>().spline = splineComputers[1];
    }
  }
  public void MergeFirstCarsButton()
  {
    if (firstCarInTheList.Count >= counter)
    {
      MergeCarsWhenThree(firstCarInTheList, tempCars, mergePositions, 0, secondCarPrefab, secondCarInTheList, 0);
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



  /*  public bool isRun;
   void Update()
   {
     if (isRun)
     {
       for (int i = firstCarInTheList.Count - 3; i < firstCarInTheList.Count; i++)
       {

         firstCarInTheList[i].transform.DOLocalMove(mergePositions.postMergePositions[0], 1);
       }
     }
   } */
}


