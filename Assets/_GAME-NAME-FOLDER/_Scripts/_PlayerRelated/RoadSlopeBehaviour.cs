using UnityEngine;
using Dreamteck.Splines;

public class RoadSlopeBehaviour : MonoBehaviour
{
  public float speed = 10f;
  public float minSpeed = 1f;
  public float maxSpeed = 20f;
  public float frictionForce = 0.1f;
  public float gravityForce = 1f;
  public float slopeRange = 60f;
  SplineFollower follower;
  public AnimationCurve speedGain;
  public AnimationCurve speedLoss;
  public float brakeSpeed = 0f;
  public float brakeReleaseSpeed = 0f;

  private float brakeTime = 0f;
  private float brakeForce = 0f;
  private float addForce = 0f;
  void Start()
  {
    follower = GetComponent<SplineFollower>();
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

    follower.followSpeed = speed;
    follower.followSpeed *= (1f - brakeForce);
    if (brakeTime > Time.time) brakeForce = Mathf.MoveTowards(brakeForce, 1f, Time.deltaTime * brakeSpeed);
    else brakeForce = Mathf.MoveTowards(brakeForce, 0f, Time.deltaTime * brakeReleaseSpeed);

  }
}

