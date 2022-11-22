using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DissolveExample;

public class CarDissolveEffects : MonoBehaviour
{
  [SerializeField] Material[] thisModelMaterials;
  [SerializeField] float durationForDissolveComplete;
  void Start()
  {
    var renderers = GetComponentsInChildren<Renderer>();
    thisModelMaterials = new Material[renderers.Length];
    for (int i = 0; i < renderers.Length; i++)
    {
      thisModelMaterials[i] = renderers[i].material;
    }
    StartCoroutine(DissolveEffect());
  }

  IEnumerator DissolveEffect()
  {
    float elapsedTime = 0;
    float value = 1;
    SetValue(value);
    while (elapsedTime < durationForDissolveComplete)
    {
      elapsedTime += Time.deltaTime;
      value = Mathf.Lerp(1, -1, elapsedTime / durationForDissolveComplete);
      SetValue(value);
      yield return null;
    }
  }

  public void SetValue(float value)
  {
    for (int i = 0; i < thisModelMaterials.Length; i++)
    {
      thisModelMaterials[i].SetVector("_DissolveOffest", new Vector3(0, value, 0));
    }
  }
}
