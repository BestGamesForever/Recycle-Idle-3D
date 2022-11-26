using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TapTutorial : MonoBehaviour
{
  // Update is called once per frame
  public bool isDanger;
  public float speed;
  public int animSpeed;


  void Update()
  {
    if (isDanger)
    {
      speed = .2f;
      transform.localScale = Vector3.one + (Vector3.one * Mathf.Sin(Time.time * animSpeed) * speed);
    }
    else
    {
      speed = .1f;
      transform.localScale = Vector3.one + (Vector3.one * Mathf.Sin(Time.time) * speed);
    }
  }
}
