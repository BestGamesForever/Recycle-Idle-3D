using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;

public abstract class CarMergeManagerBase : MonoBehaviour
{
  public CarMergeManager carMergeManager;
  Transform spawnPoints;
  public Transform[] carsParents;
  public PoolingManager poolManager;
  public static event Action effectPlay;
  void Start()
  {
    spawnPoints = FindObjectOfType<SpawnPoint>().transform;
  }
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
      temp[i].GetComponent<Rotate>().enabled = true;
    }
    StartCoroutine(NewCarSpawn(temp, nextCar, newCar, parentIndex));
  }
  IEnumerator NewCarSpawn(List<CarsLoopBehaviour> CarInTheList, GameObject nextCar, List<CarsLoopBehaviour> nextCarList, int parentIndex)
  {
    yield return new WaitForSeconds(2f);
    effectPlay?.Invoke();
    yield return new WaitForSeconds(.1f);
    GameObject nextCarGo = Instantiate(nextCar);

    nextCarGo.transform.DOMove(spawnPoints.position, .75f).SetDelay(.5f).OnComplete(() => OnCompleteSpawn(nextCarGo));
    nextCarGo.transform.SetParent(carsParents[parentIndex]);
    nextCarGo.transform.localPosition = new Vector3(-480.5f, -347.5f, -20f);
    nextCarList.Add(nextCarGo.GetComponent<CarsLoopBehaviour>());
    for (int i = 0; i < 3; i++)
    {
      CarInTheList[i].gameObject.SetActive(false);
    }
    carMergeManager.ListCarsReferences();
  }

  void OnCompleteSpawn(GameObject nextCarGo)
  {
    Debug.Log($"GameObject  {gameObject}");
    nextCarGo.GetComponent<SplineFollower>().enabled = true;
    nextCarGo.GetComponent<CarsLoopBehaviour>().enabled = true;
    nextCarGo.GetComponent<RoadSlopeBehaviour>().enabled = true;
    nextCarGo.transform.GetChild(0).GetComponent<CarToCheckAtSpawn>().enabled = true;
  }

  public IEnumerator SecondCarInstantiate(GameObject nextCar, List<CarsLoopBehaviour> nextCarList, int parentIndex)
  {
    for (int i = 0; i < GameManager.Instance.secondCarListCount; i++)
    {
      if (GameManager.Instance.secondCarListCount > 0)
      {
        GameObject nextCarGo = Instantiate(nextCar);
        nextCarGo.transform.DOMove(spawnPoints.position, .1f).SetDelay(.5f).OnComplete(() => OnCompleteSpawn(nextCarGo));
        nextCarGo.transform.SetParent(carsParents[parentIndex]);
        nextCarList.Add(nextCarGo.GetComponent<CarsLoopBehaviour>());
        carMergeManager.ListCarsReferences();
        yield return new WaitForSeconds(.5f);
      }

    }

  }
}
