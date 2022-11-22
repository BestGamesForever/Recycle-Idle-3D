using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Cars", menuName = "Cars")]
public class Cars : ScriptableObject
{
  public List<Transform> carsToSpawn;
}
