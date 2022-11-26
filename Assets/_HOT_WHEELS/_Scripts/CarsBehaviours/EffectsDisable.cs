using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsDisable : MonoBehaviour
{
  SpriteRenderer spriteRenderer;
  Animator anim;
  void OnEnable()
  {
    CarMergeManagerBase.effectPlay += PlayAnimation;
  }

  void OnDisable()
  {
    CarMergeManagerBase.effectPlay -= PlayAnimation;
  }
  private void PlayAnimation()
  {
    spriteRenderer.enabled = true;
    anim.Play("Effect");
  }
  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
  }
  void DisableThis()
  {
    spriteRenderer.enabled = false;
  }
}
