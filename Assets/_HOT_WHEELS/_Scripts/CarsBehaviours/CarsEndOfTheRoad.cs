using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using System;

public class CarsEndOfTheRoad : MonoBehaviour
{
  private SplineFollower splineFollower;
  [SerializeField] float duration;
  Transform spawnPoint;
  public static event Action OnSpeedAtTheStart = delegate { };
  public static event Action onPlatformMoving = delegate { };
  GameObject tempPlatform;
  void OnEnable()
  {
    splineFollower = GetComponent<SplineFollower>();
    spawnPoint = FindObjectOfType<SpawnPoint>().transform;
  }
  public void ReachEndOfTheRoad()
  {
    StartCoroutine(TurnBackToStart());
  }
  IEnumerator TurnBackToStart()
  {
    splineFollower.enabled = false;
    float elapsedTime = 0;
    float y = 0;
    float yRot = transform.eulerAngles.y;
    Vector3 startPos = transform.position;
    onPlatformMoving?.Invoke();
    while (elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;
      y = Mathf.Lerp(yRot, yRot - 180, elapsedTime / duration);
      transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));
      transform.position = Vector3.Lerp(startPos, spawnPoint.position, elapsedTime / duration);
      yield return null;
    }
    yield return new WaitForEndOfFrame();
    splineFollower.SetPercent(0);
    splineFollower.enabled = true;
    OnSpeedAtTheStart?.Invoke();

  }
}
