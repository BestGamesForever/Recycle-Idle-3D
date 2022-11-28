
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using System.Collections;

public class PoolingManager : MonoBehaviour
{

  [SerializeField] CarMergeManager carMergeManager;
  [SerializeField] CarMergeManagerBase carMergeManagerBase;
  public ButtonInteractableCheck mergeButtonCheck;
  CarMergeManager roadAndSpawnManager;
  [SerializeField] private GameObject[] parents;
  [SerializeField] private GameObject carPrefab;
  [SerializeField] private GameObject secondCarPrefab;
  GameObject createdCar;
  public List<GameObject> carPool = new List<GameObject>();
  public List<GameObject> tempPool = new List<GameObject>();
  [SerializeField] int poolStartSize;
  Transform spawnPoints;
  [SerializeField] SpawnPositionOffsets offset;
  public int listCount;

  void OnEnable()
  {
    SelectSkills.spawnFirstCar += SpawnACar;
  }
  void OnDisable()
  {
    SelectSkills.spawnFirstCar += SpawnACar;//SelectSkills Action
  }

  private void SpawnACar()
  {
    GetCar();
  }

  IEnumerator Start()
  {
    spawnPoints = FindObjectOfType<SpawnPoint>().transform;
    roadAndSpawnManager = GetComponent<CarMergeManager>();
    listCount = -1;
    for (int i = 0; i < GameManager.Instance.firstCarListCount + 1; i++)
    {
      createdCar = Instantiate(carPrefab);
      carPool.Add(createdCar);
      roadAndSpawnManager.firstCarInTheList.Add(createdCar.GetComponent<CarsLoopBehaviour>());
      createdCar.SetActive(true);
      createdCar.transform.SetParent(parents[0].transform);
      createdCar.transform.GetChild(0).GetComponent<CarToCheckAtSpawn>().enabled = false;
      carMergeManager.ListCarsReferences();
      yield return new WaitForSeconds(.5f);
    }
    StartCoroutine(carMergeManagerBase.SecondCarInstantiate(secondCarPrefab, carMergeManager.secondCarInTheList, 0));

  }
  public GameObject GetCar()
  {
    tempPool = new List<GameObject>();
    {
      listCount++;
      for (int i = 0; i < 1; i++)
      {
        int index = GameManager.Instance.addRoadButtonClicked;
        createdCar = Instantiate(carPrefab);
        createdCar.transform.position = spawnPoints.position + offset.offsets[index];
        carPool.Add(createdCar);
        roadAndSpawnManager.firstCarInTheList.Add(createdCar.GetComponent<CarsLoopBehaviour>());
        createdCar.GetComponent<CarsLoopBehaviour>().isFirstSpawn = true;
        createdCar.SetActive(true);
        createdCar.transform.SetParent(parents[0].transform);
        createdCar.GetComponent<SplineFollower>().enabled = false;
        carMergeManager.ListCarsReferences();
      }
      GameManager.Instance.firstCarListCount = carPool.Count;
      Debug.Log($"Counter  {GameManager.Instance.firstCarListCount}");
      foreach (GameObject item in carPool)
      {
        if (item.activeInHierarchy)
        {
          tempPool.Add(item);
        }
      }
      mergeButtonCheck.CheckMergeButtonWhenReachThreeCars(tempPool.Count);
      return createdCar;
    }
  }

  public void ReturnProjectile(GameObject projectile)
  {
    for (int i = 0; i < 3; i++)
    {
      // projectilePool.Enqueue(projectile);
      projectile.SetActive(false);
    }
  }
}

