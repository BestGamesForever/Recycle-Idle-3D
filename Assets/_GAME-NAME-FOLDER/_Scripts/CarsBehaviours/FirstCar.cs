using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCar : BaseCarBehaviour
{
  private void Start()
  {
    base.OnEnables();
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Box"))
    {
      Debug.Log($"tota  {gameObject}");
      base.GiveMoney(3);
    }

  }

}
