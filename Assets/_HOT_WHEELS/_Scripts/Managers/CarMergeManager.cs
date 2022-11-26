using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;

public class CarMergeManager : CarMergeManagerBase
{
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


