using Cinemachine;
using UnityEngine;

public class ShakeCameras : MonoBehaviour
{
    CinemachineVirtualCamera _virCam;
    float _shaketimer;
    private void Awake()
    {
        _virCam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (_shaketimer >= 0)
        {
            _shaketimer -= Time.deltaTime;
            if (_shaketimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin _perlin = _virCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                _perlin.m_AmplitudeGain = 0;
            }
        }
    }
    public void Camshake(float intensify, float timer)
    {       
        CinemachineBasicMultiChannelPerlin _perlin = _virCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _perlin.m_AmplitudeGain = intensify;
        _shaketimer = timer;
    }
}
