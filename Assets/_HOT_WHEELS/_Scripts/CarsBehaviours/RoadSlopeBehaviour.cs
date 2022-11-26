using UnityEngine;
using Dreamteck.Splines;
using System;

public class RoadSlopeBehaviour : MonoBehaviour
{
  int layerMask;
  Transform fasterEffect;
  SplineFollower follower;
  public float speed = 10f;
  public float minSpeed = 1f;
  public float maxSpeed = 20f;
  public float frictionForce = 0.1f;
  public float gravityForce = 1f;
  public float slopeRange = 60f;
  public AnimationCurve speedGain;
  public AnimationCurve speedLoss;
  public float brakeSpeed = 0f;
  public float brakeReleaseSpeed = 0f;

  private float brakeTime = 0f;
  private float brakeForce = 0f;
  private float addForce = 0f;
  float multiplier;

  Ray ray;
  RaycastHit hitInfo;

  void OnEnable()
  {
    CarsEndOfTheRoad.OnSpeedAtTheStart += SpeedAtTheStart;
    layerMask = LayerMask.NameToLayer("FirstCar");
  }
  void OnDisable()
  {
    CarsEndOfTheRoad.OnSpeedAtTheStart -= SpeedAtTheStart;
  }

  private void SpeedAtTheStart()
  {
    speed = 5;
  }

  void Start()
  {
    multiplier = 1;
    follower = GetComponent<SplineFollower>();
    fasterEffect = transform.GetChild(1);
  }

  void Update()
  {

    float dot = Vector3.Dot(this.transform.forward, Vector3.down);
    float dotPercent = Mathf.Lerp(-slopeRange / 90f, slopeRange / 90f, (dot + 1f) / 2f);
    speed -= Time.deltaTime * frictionForce * (1f - brakeForce);
    float speedAdd = 0f;
    float speedPercent = Mathf.InverseLerp(minSpeed, maxSpeed, speed);
    if (dotPercent > 0f)
    {
      speedAdd = gravityForce * dotPercent * speedGain.Evaluate(speedPercent) * Time.deltaTime;
    }
    else
    {
      speedAdd = gravityForce * dotPercent * speedLoss.Evaluate(1f - speedPercent) * Time.deltaTime;
    }
    speed += speedAdd * (1f - brakeForce);
    speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    if (PlayerController._gameState == GameState.Run)
    {
      multiplier = 2;
      fasterEffect.gameObject.SetActive(true);

    }
    else
    {
      multiplier = 1;
      fasterEffect.gameObject.SetActive(false);
    }
    ray = new Ray(transform.position, transform.forward);
    if (Physics.Raycast(ray, out hitInfo, 2))
    {
      if (hitInfo.collider.gameObject.layer == layerMask)
      {
        multiplier *= .1f;
      }
    }
    else
    {
      multiplier *= 1;
    }
    Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
    follower.followSpeed = speed * multiplier;
    follower.followSpeed *= (1f - brakeForce);
    if (brakeTime > Time.time) brakeForce = Mathf.MoveTowards(brakeForce, 1f, Time.deltaTime * brakeSpeed);
    else brakeForce = Mathf.MoveTowards(brakeForce, 0f, Time.deltaTime * brakeReleaseSpeed);
  }
}


