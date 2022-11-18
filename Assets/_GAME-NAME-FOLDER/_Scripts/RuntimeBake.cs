using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class RuntimeBake : MonoBehaviour
{
  public List<SplineComputer> computers;
  void Awake()
  {
    Debug.Log($"computers.Count  {computers.Count}");
  }
  public void ChangeRoad()
  {
    computers[0].gameObject.SetActive(false);
    computers.RemoveAt(0);
    computers[0].gameObject.SetActive(true);
    GetComponent<SplineFollower>().spline = computers[0];
  }

}
