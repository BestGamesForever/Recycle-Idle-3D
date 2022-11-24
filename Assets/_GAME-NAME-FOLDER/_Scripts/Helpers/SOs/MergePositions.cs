using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Positions", fileName = "MergingPositions")]
public class MergePositions : ScriptableObject
{
  public Vector3[] preMergePositions;
  public Vector3[] postMergePositions;
  public float[] postMergePercentages;
}
