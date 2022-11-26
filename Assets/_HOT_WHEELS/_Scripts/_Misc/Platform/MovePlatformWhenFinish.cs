using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformWhenFinish : MonoBehaviour
{
  WaitForSeconds waitForSeconds;
  [SerializeField] float duration;
  [SerializeField] Vector3 offset;
  Transform spawnPoint;
  Vector3 startPoint;
  void OnEnable()
  {
    CarsEndOfTheRoad.onPlatformMoving += MovePlatformInTheCarsEnd;
  }
  void Start()
  {
    waitForSeconds = new WaitForSeconds(.2f);
    spawnPoint = FindObjectOfType<SpawnPoint>().transform;
    startPoint = transform.position;

  }
  void OnDisable()
  {
    CarsEndOfTheRoad.onPlatformMoving -= MovePlatformInTheCarsEnd;
  }
  void MovePlatformInTheCarsEnd()
  {
    StartCoroutine(MovePlatform());
  }

  IEnumerator MovePlatform()
  {
    float elapsedTime = 0;
    Vector3 startPos = transform.position;
    while (elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;
      transform.position = Vector3.Lerp(startPos, spawnPoint.position + offset, elapsedTime / duration);
      yield return null;
    }
    yield return waitForSeconds;
    transform.position = startPoint;
    gameObject.SetActive(false);

  }
}

