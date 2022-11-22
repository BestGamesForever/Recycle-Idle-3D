using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class CarToCheckAtSpawn : MonoBehaviour
{
  public Vector3 offset;
  private bool m_Started;
  public LayerMask mLayerMask;
  public float distance;
  int index;
  float timer;
  Transform parentObject;
  Vector3 targetPosition;

  void OnEnable()
  {
    m_Started = true;
    timer = 1f;
    parentObject = transform.parent;
    targetPosition = parentObject.position - new Vector3(0, .5f, 0);
  }
  void FixedUpdate()
  {
    MyCollisions();
    StartTheCar();
  }

  void MyCollisions()
  {
    Collider[] hitColliders = Physics.OverlapBox(transform.position + offset * distance, transform.localScale + offset, Quaternion.identity, mLayerMask);
    index = 0;
    if (index < hitColliders.Length)
    {
      Debug.Log("Hit : " + hitColliders[index].name + index);
      m_Started = false;
      index++;
    }
    else
    {
      m_Started = true;
    }
  }
  void StartTheCar()
  {
    if (m_Started)
    {
      timer -= Time.fixedDeltaTime;
      if (timer < .2f)
      {
        parentObject.position = Vector3.Lerp(parentObject.position, targetPosition, timer);
      }
      if (timer <= 0)
      {
        transform.parent.GetComponent<SplineFollower>().enabled = true;
        this.enabled = false;
        m_Started = false;
      }
    }
  }
  /*  void OnDrawGizmos()
   {
     Gizmos.color = Color.red;
     if (m_Started)
       Gizmos.DrawWireCube(transform.position + offset * distance, transform.localScale + offset);
   } */
}

