
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PoolingManager : MonoBehaviour
{
  RoadAndSpawnManager roadAndSpawnManager;
  [SerializeField] private GameObject[] parents;
  [SerializeField] private GameObject _projectilePrefab;
  public List<GameObject> projectilePool = new List<GameObject>();
  [SerializeField] int poolStartSize;
  GameObject projectile;
  Transform spawnPoints;
  [SerializeField] Vector3 offset;
  int totalCounter;
  int listCount;

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
    GetProjectile();
  }

  private void Start()
  {
    spawnPoints = FindObjectOfType<SpawnPoint>().transform;
    roadAndSpawnManager = GetComponent<RoadAndSpawnManager>();
    listCount = -1;
    for (int i = 0; i < poolStartSize; i++)
    {
      projectile = Instantiate(_projectilePrefab);
      projectilePool.Add(projectile);
      roadAndSpawnManager.allCarsInThisList.Add(projectile.GetComponent<CarsLoopBehaviour>());
      projectile.SetActive(true);
      projectile.transform.GetChild(0).GetComponent<CarToCheckAtSpawn>().enabled = false;
      totalCounter = projectilePool.Count;

    }
  }
  public GameObject GetProjectile()
  {
    {
      listCount++;
      projectile = projectilePool[listCount];
      projectile.SetActive(true);

      for (int i = 0; i < 1; i++)
      {
        projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = spawnPoints.position + offset;
        projectilePool.Add(projectile);
        roadAndSpawnManager.allCarsInThisList.Add(projectile.GetComponent<CarsLoopBehaviour>());
        projectile.GetComponent<CarsLoopBehaviour>().isFirstSpawn = true;
        projectile.SetActive(true);
        projectile.transform.SetParent(parents[0].transform);
        projectile.GetComponent<SplineFollower>().enabled = false;
      }
      return projectile;
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

