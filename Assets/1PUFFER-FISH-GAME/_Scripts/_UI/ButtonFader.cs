using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ButtonFader : MonoBehaviour
{
  public Image itself;
  public TextMeshProUGUI sellText;
  public float duration;

  private void OnEnable()
  {
    // duration = 2;//ElephantSDK.RemoteConfig.GetInstance().GetFloat("NoThanksClaimButton_Time", 2);
    // TODO: DoTween fade 

    itself.DOFade(1, 1).SetDelay(duration);
    sellText.DOFade(1, 1).SetDelay(duration);

  }
}
