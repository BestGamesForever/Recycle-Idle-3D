using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EventManager : MonoBehaviour
{
  public static EventManager instance;
  Vector3 offset;
  public UIScript uiscript;
  public Animator anim;

  public Vector3 punch;

  private void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    offset = new Vector3(.6f, 0, 0);
  }

  public delegate void HitEachOtherParticle(Vector3 particlePos, ParticleSystem hitParticle, bool isHealtDecrease);
  public static event HitEachOtherParticle _hiteachOther;

  public delegate void camShake();
  public static event camShake _camShake;

  public delegate void ButtonCheck();
  public static event ButtonCheck onButtonCheck;


  public void OnButtonCheckFunc()
  {
    onButtonCheck();
  }

  public void ButtonAndCorrespondComponentAnim(Transform clickedButton, Transform icon, Transform correspondTransform, Transform currentTransform)
  {
    if (clickedButton != null)
    {
      clickedButton.GetComponent<Button>().interactable = false;
      clickedButton.DOPunchScale(punch, .4f, 5, 1f).OnComplete(() => clickedButton.GetComponent<Button>().interactable = true);
    }
    if (icon != null)
    {
      icon.DOPunchScale(punch * .2f, .4f, 1, 1f).OnComplete(() => icon.localScale = Vector3.one);
    }
    correspondTransform.DOPunchScale(punch, .4f, 5, 1f).OnComplete(() => correspondTransform.localScale = Vector3.one);
    currentTransform.DOShakeScale(1, .5f, 5, 20f, true).OnComplete(() => currentTransform.localScale = Vector3.one);
  }

  public void HitEachOtherParticleFunc(ParticleSystem hitParticleSystem, bool isHealtDecrease)
  {
    Vector3 _particlePos = Vector3.zero;
    _hiteachOther(_particlePos, hitParticleSystem, isHealtDecrease);
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

  public void ChangeColorsOfTheBodyWhenHit(Renderer baseMesh, Texture mainTexture)
  {
    StartCoroutine(GetHitAndChangeTheOutline(baseMesh, mainTexture));
  }
  bool isGetHit;
  public Texture whiteTexture;
  IEnumerator GetHitAndChangeTheOutline(Renderer baseMesh, Texture mainTexture)
  {
    float elapsedTime = 0;
    float duration = .03f;
    baseMesh.GetComponent<Renderer>().material.SetTexture("_BaseMap", mainTexture);
    isGetHit = true;
    while (isGetHit && elapsedTime < duration)
    {
      elapsedTime += Time.deltaTime;

      baseMesh.GetComponent<Renderer>().material.SetTexture("_BaseMap", whiteTexture);
      yield return new WaitForSeconds(.1f);

      baseMesh.GetComponent<Renderer>().material.SetTexture("_BaseMap", mainTexture);
      yield return new WaitForSeconds(.1f);
      yield return null;

    }
    isGetHit = false;
    baseMesh.GetComponent<Renderer>().material.SetTexture("_BaseMap", mainTexture);

  }
}
