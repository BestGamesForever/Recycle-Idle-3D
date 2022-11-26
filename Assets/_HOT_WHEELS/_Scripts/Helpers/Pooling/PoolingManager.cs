
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PoolingManager : MonoBehaviour
{
  public ButtonInteractableCheck mergeButtonCheck;
  CarMergeManager roadAndSpawnManager;
  [SerializeField] private GameObject[] parents;
  [SerializeField] private GameObject carPrefab;
  GameObject createdCar;
  public List<GameObject> carPool = new List<GameObject>();
  public List<GameObject> tempPool = new List<GameObject>();
  [SerializeField] int poolStartSize;
  Transform spawnPoints;
  [SerializeField] Vector3 offset;
  public int listCount;

  void OnEnable()
  {
    SelectSkills.SpawnFirstCar += SpawnACar;
  }
  void OnDisable()
  {
    SelectSkills.SpawnFirstCar += SpawnACar;//SelectSkills Action
  }

  private void SpawnACar()
  {
    GetCar();
  }

  private void Start()
  {
    spawnPoints = FindObjectOfType<SpawnPoint>().transform;
    roadAndSpawnManager = GetComponent<CarMergeManager>();
    listCount = -1;
    for (int i = 0; i < poolStartSize; i++)
    {
      createdCar = Instantiate(carPrefab);
      carPool.Add(createdCar);
      roadAndSpawnManager.firstCarInTheList.Add(createdCar.GetComponent<CarsLoopBehaviour>());
      createdCar.SetActive(true);
      createdCar.transform.GetChild(0).GetComponent<CarToCheckAtSpawn>().enabled = false;
    }
  }
  public GameObject GetCar()
  {
    tempPool = new List<GameObject>();
    {
      listCount++;
      Debug.Log($"listCount  {listCount}");

      for (int i = 0; i < 1; i++)
      {
        createdCar = Instantiate(carPrefab);
        createdCar.transform.position = spawnPoints.position + offset;
        carPool.Add(createdCar);
        roadAndSpawnManager.firstCarInTheList.Add(createdCar.GetComponent<CarsLoopBehaviour>());
        createdCar.GetComponent<CarsLoopBehaviour>().isFirstSpawn = true;
        createdCar.SetActive(true);
        createdCar.transform.SetParent(parents[0].transform);
        createdCar.GetComponent<SplineFollower>().enabled = false;
      }

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

