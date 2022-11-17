using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instane;
    Vector3 offset;
    public UIScript uiscript;
    public Animator anim;

    private void Awake()
    {
        instane = this;
    }

    private void Start()
    {
        offset = new Vector3(0, 1, 0);
    }

    public delegate void _ParticleHitWall(Vector3 hitObjPos);
    public static event _ParticleHitWall _particleHit;
    public delegate void CounterLog();
    public static event CounterLog _counterLog;
    public delegate void BombParticle(Vector3 ParticlePos);
    public static event BombParticle _bombParticle;
    public delegate void HitEachOtherParticle(Vector3 particlePos);
    public static event HitEachOtherParticle _hiteachOther;
    public delegate void CheckIfHitFoods();
    public static event CheckIfHitFoods _checkIfCutSpeed;
    public delegate void EndParticle();
    public static event EndParticle _endParticle;
    public delegate void SuccessEndGame(int multiplier);
    public static event SuccessEndGame _success;
    public delegate void DisableAndEnableJelly(Transform other);
    public static event DisableAndEnableJelly _disenablePunch;
    public delegate void CombineAndTouch(GameObject obj);
    public static event CombineAndTouch _combineAndTouch;
    public delegate void camShake();
    public static event camShake _camShake;
    public delegate void Diamondcounter();

    public static event Diamondcounter _diamondcounter;
    public delegate void EndSceneUI();
    public static event EndSceneUI _endSceneUI;
    public delegate void CounterLogWhileLogsDispatched();
    public static event CounterLogWhileLogsDispatched _counterLogWhileLogsDispatched;

    public delegate void MovieStart();
    public static event MovieStart _movieStart;

    public void CounterLogWhileLogsDispatchedFunc()
    {
        _counterLogWhileLogsDispatched();
    }

    public void DiamondCounterFunc()
    {
        _diamondcounter();
    }

    public void HitWallParticle()
    {
        // Vector3 hitObj = CombineCubes.hitObjPosition;
        // _particleHit(hitObj);
        //
    }

    public void CombineParticleFunc(GameObject obj, GameObject other)
    {
        //Vector3 _particlePos = CombineCubes._aftercombinePos;
        //_combineParticle(_particlePos);
        //StartCoroutine(mesh(obj, other));
    }

    public void BombParticleFunc()
    {
        // Vector3 hitObj = CombineCubes.hitObjPosition;
        // _bombParticle(hitObj);
    }

    public void HitEachOtherParticleFunc()
    {
        //Vector3 _particlePos = CombineCubes.hitObjPosition + offset;
        //_hiteachOther(_particlePos);
    }

    public void EndSceneUIFunc()
    {
        _endSceneUI();
    }

    public void CounterLogFunc()
    {
        _counterLog();
    }

    public void DisableEnableJelly(GameObject obj, GameObject other)
    {
        StartCoroutine(mesh(obj, other));
    }

    IEnumerator mesh(GameObject obj, GameObject other)
    {
        obj.GetComponent<MeshFilter>().mesh = other.GetComponent<MeshFilter>().mesh;
        yield return null;
    }

    public void CheckIfCutSpeed()
    {
        _checkIfCutSpeed();
    }

    public void DisenablePunchFunc(Transform other)
    {
        _disenablePunch(other);
    }

    public void EndSceneParticle()
    {
        _endParticle();
    }

    public void Success()
    {
        int rand = Random.Range(1, 10);
        _success(rand);
    }

    public void CombineAndTouchFunc(GameObject obj)
    {
        _combineAndTouch(obj);
    }

    public void CamShakeFunc()
    {
        // _camShake();
        Debug.Log("Haptic");
    }

    public void GratificationFunc()
    {
        StartCoroutine(Gratification());
    }

    IEnumerator Gratification()
    {
        yield return new WaitForSeconds(.5f);
        uiscript.GratifyUser();
        anim.Play("UI");
    }

    public void MovieStartFunc()
    {
        _movieStart();
    }
}
