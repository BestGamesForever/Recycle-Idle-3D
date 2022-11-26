using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
  WaitForSeconds waitForSeconds;
  public float _maksRange;
  public float OffsetValue;
  public float speed;
  public float tempSpeed;
  public bool isUI;
  public AnimationCurve animationCurve;
  void OnEnable()
  {
    waitForSeconds = new WaitForSeconds(.5f);
    tempSpeed = Random.Range(50, 250);
    StartCoroutine(Rotator());
  }
  IEnumerator Rotator()
  {
    yield return waitForSeconds;
    while (true)
    {
      speed = Mathf.Lerp(speed, tempSpeed, animationCurve.Evaluate(Time.time));
      Debug.Log($"speed  {speed}");
      transform.rotation = Quaternion.Euler(transform.rotation.x, speed * Time.time * 2, transform.rotation.z);
      yield return null;
    }

  }
}
