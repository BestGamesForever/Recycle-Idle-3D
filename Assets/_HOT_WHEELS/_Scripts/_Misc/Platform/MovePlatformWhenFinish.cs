using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformWhenFinish : MonoBehaviour
{
  WaitForSeconds waitForSeconds;
  [SerializeField] float duration;
  [SerializeField] Vector3[] offset;
  Transform spawnPoint;
  Vector3 startPoint;
  void OnEnable()
  {
    CarsEndOfTheRoad.onPlatformMoving += MovePlatformInTheCarsEnd;
  }
  IEnumerator Start()
  {
    waitForSeconds = new WaitForSeconds(.05f);
    yield return waitForSeconds;
    spawnPoint = FindObjectOfType<SpawnPoint>().transform;
    Debug.Log($"spawnPoint  {spawnPoint.transform.parent.name}");
    startPoint = transform.localPosition;

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
    Vector3 startPos = transform.localPosition;
    while (elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;
      transform.localPosition = Vector3.Lerp(startPos, spawnPoint.localPosition + offset[GameManager.Instance.addRoadButtonClicked], elapsedTime / duration);
      yield return null;
    }
    yield return waitForSeconds;
    transform.localPosition = startPoint;
    gameObject.SetActive(false);
  }
}

