using System.Collections;
using UnityEngine;
using Dreamteck.Splines;

public enum CarType
{
  FirstCar,
  SecondCar,
  ThirdCar,
  FourthCar
}
public class CarsLoopBehaviour : BaseCarBehaviour
{
  SplineFollower splineFollower;
  CarsEndOfTheRoad carsEndOfTheRoad;
  public CarType carType;
  public bool isFirstSpawn;
  Ray ray;
  RaycastHit hitInfo;
  IEnumerator StartCarLoop;
  public Vector3 offset;
  float duration;
  private void OnEnable()
  {
    splineFollower = GetComponent<SplineFollower>();
    splineFollower.SetPercent(0);
    duration = 1;

    // StartCarLoop = StartCarLooping();
  }
  private void Start()
  {
    carsEndOfTheRoad = GetComponent<CarsEndOfTheRoad>();
    base.OnEnables();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other == null)
    {
      Debug.Log($"other");
    }
    ICheckPoints checkPoints = other.GetComponent<ICheckPoints>();
    IEndTrigger endPoint = other.GetComponent<IEndTrigger>();
    if (checkPoints != null)
    {
      switch (carType)
      {
        case CarType.FirstCar:
          base.GiveMoney(10);
          break;
        case CarType.SecondCar:
          base.GiveMoney(20);
          break;
        default:
          base.GiveMoney(0);
          break;
      }
    }
    if (endPoint != null)
    {
      carsEndOfTheRoad.ReachEndOfTheRoad();
    }
  }
  /* 
    private void OnTriggerStay(Collider other)
    {
      ICarsToCheck checkPoints = other.GetComponent<ICarsToCheck>();
      if (checkPoints != null)
      {
        Debug.Log($"other  {other.gameObject}");

        return;

      }
      else
      {
        StartCoroutine(StartCarLooping());
      }
    }

    IEnumerator StartCarLooping()
    {
      yield return new WaitForSeconds(duration);
      GetComponent<SplineFollower>().enabled = true;
      transform.GetChild(0).GetComponent<Collider>().enabled = false;
    } */

}
