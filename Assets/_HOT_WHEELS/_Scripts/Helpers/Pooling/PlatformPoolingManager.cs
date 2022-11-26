using System.Collections.Generic;
using UnityEngine;

public class PlatformPoolingManager : MonoBehaviour
{
  [SerializeField] GameObject platformParent;
  [SerializeField] GameObject platformPrefab;
  [SerializeField] List<GameObject> poolingList;
  [SerializeField] int poolStartSize;
  GameObject platformItself;
  Transform spawnPoints;
  [SerializeField] Vector3 offset;
  int totalCounter;


  void OnEnable()
  {
    totalCounter = -1;
    poolingList = new List<GameObject>();
    CarsEndOfTheRoad.onPlatformMoving += SpawnThePlatform;
  }
  void OnDisable()
  {
    CarsEndOfTheRoad.onPlatformMoving -= SpawnThePlatform;//SelectSkills Action
  }

  private void SpawnThePlatform()
  {
    GetPlatform();
  }

  private void Start()
  {

    spawnPoints = FindObjectOfType<SpawnPoint>().transform;
    for (int i = 0; i < poolStartSize; i++)
    {
      platformItself = Instantiate(platformPrefab);
      platformItself.transform.SetParent(platformParent.transform);
      platformItself.SetActive(false);
      poolingList.Add(platformItself);
    }
  }
  public GameObject GetPlatform()
  {
    totalCounter++;
    for (int i = 0; i < poolingList.Count; i++)
    {
      platformItself = poolingList[totalCounter % poolingList.Count].gameObject;
      platformItself.SetActive(true);
    }
    return platformItself;
  }
  public void ReturnProjectile(GameObject projectile)
  {
    for (int i = 0; i < 1; i++)
    {
      platformItself.SetActive(false);
    }
  }
}

