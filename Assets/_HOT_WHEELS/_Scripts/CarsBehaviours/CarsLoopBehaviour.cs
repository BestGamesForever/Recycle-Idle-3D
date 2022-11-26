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
  int layerMask;
  private void OnEnable()
  {
    splineFollower = GetComponent<SplineFollower>();
    splineFollower.SetPercent(0);
    layerMask = LayerMask.NameToLayer("FirstCar");
    duration = 1;
  }
  private void Start()
  {
    carsEndOfTheRoad = GetComponent<CarsEndOfTheRoad>();
    base.OnEnables();
  }

  private void OnTriggerEnter(Collider other)
  {
    ICheckPoints checkPoints = other.GetComponent<ICheckPoints>();
    IEndTrigger endPoint = other.GetComponent<IEndTrigger>();
    if (checkPoints != null)
    {
      switch (carType)
      {
        case CarType.FirstCar:
          base.GiveMoney(10);
          checkPoints.SpawnMoney();
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

  private void OnTriggerStay(Collider other)
  {

    /*  if (other.gameObject.layer == layerMask)
     {
       Debug.Log($"other  {other.gameObject.name}");
       GetComponent<RoadSlopeBehaviour>().enabled = false;
     } */
  }
}
