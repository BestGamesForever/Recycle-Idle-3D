using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public  float _maksRange;
    public float OffsetValue;
    public float _speed;
    public bool isUI;

    private void Update()
    {
        if (!isUI)
        {
            transform.rotation = Quaternion.Euler(90, Mathf.PingPong(Time.time * _speed, _maksRange) - OffsetValue, 0);
        }
        if (isUI)
        {
            transform.rotation = Quaternion.Euler(0, 0,20* Time.time);
        }
       
    }
}
