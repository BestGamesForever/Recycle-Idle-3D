using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;

public abstract class CarMergeManagerBase : MonoBehaviour
{
  public Transform[] carsParents;
  public PoolingManager poolManager;
  public static event Action effectPlay;
  public virtual void MergeCarsWhenThree(List<CarsLoopBehaviour> CarInTheList, List<CarsLoopBehaviour> temp, MergePositions mergePositions, int index, GameObject nextCar, List<CarsLoopBehaviour> newCar, int parentIndex)
  {
    temp = new List<CarsLoopBehaviour>();
    foreach (CarsLoopBehaviour item in CarInTheList)
    {
      if (item.gameObject.activeInHierarchy)
      {
        temp.Add(item);
      }
    }
    for (int i = 0; i < 3; i++)
    {
      temp[i].GetComponent<SplineFollower>().enabled = false;
      temp[i].GetComponent<RoadSlopeBehaviour>().enabled = false;
      temp[i].GetComponent<CarsLoopBehaviour>().enabled = false;
      temp[i].transform.DOLocalMove(mergePositions.preMergePositions[index], 1);
      temp[i].transform.DOScale(new Vector3(.1f, .1f, .1f), 1).SetDelay(1);
    }
    StartCoroutine(Test(temp, nextCar, newCar, parentIndex));
  }
  IEnumerator Test(List<CarsLoopBehaviour> CarInTheList, GameObject nextCar, List<CarsLoopBehaviour> nextCarList, int parentIndex)
  {
    yield return new WaitForSeconds(2f);
    effectPlay?.Invoke();
    yield return new WaitForSeconds(.1f);
    GameObject nextCarGo = Instantiate(nextCar);
    nextCarGo.transform.SetParent(carsParents[parentIndex]);
    nextCarGo.transform.localPosition = new Vector3(-480.5f, -347.5f, -20f);
    nextCarGo.GetComponent<SplineFollower>().enabled = false;
    nextCarList.Add(nextCarGo.GetComponent<CarsLoopBehaviour>());
    for (int i = 0; i < 3; i++)
    {
      CarInTheList[i].gameObject.SetActive(false);
    }
  }
}
