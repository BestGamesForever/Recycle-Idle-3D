using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using TMPro;

public class UIScript : MonoBehaviour
{
  public static int currentLevel;
  public static int totalCoins;
  public static bool completedTutorial = false;
  int levelReward;

  [SerializeField]
  Transform gratificationTexts;
  [SerializeField]
  float gratificationDuration;

  [BoxGroup("Texts")]
  [SerializeField]
  TextMeshProUGUI levelTextHUD;
  [BoxGroup("Texts")]
  [SerializeField]
  TextMeshProUGUI levelTextEndUI;
  [BoxGroup("Texts")]
  [SerializeField]
  TextMeshProUGUI levelRewardText;
  [BoxGroup("Texts")]
  [SerializeField]
  TextMeshProUGUI totalCoinsText;



  [BoxGroup("Texts")]
  public
  TextMeshProUGUI itemCountText;

  [BoxGroup("Visuals")]
  [SerializeField] Transform icon;

  public delegate TextMeshProUGUI OnGetCurrentMoneyText();
  public static OnGetCurrentMoneyText onGetMoneyText;
  public delegate Transform OnGetMoneyIcon();
  public static OnGetMoneyIcon onGetMoneyIcon;
  private void Awake()
  {
    currentLevel = GameManager.Instance.currentLevel;
    totalCoins = GameManager.Instance.totalCoins;
    completedTutorial = GameManager.Instance.completedTutorial;
  }
  void OnEnable()
  {
    onGetMoneyText += GetTotalMoneyText;
    onGetMoneyIcon += GetIcon;
  }
  void OnDisable()
  {
    onGetMoneyText -= GetTotalMoneyText;
    onGetMoneyIcon -= GetIcon;
  }

  public TextMeshProUGUI GetTotalMoneyText()
  {
    return itemCountText;
  }

  private Transform GetIcon()
  {
    return icon;
  }
  void Start()
  {
    levelReward = UnityEngine.Random.Range(20, 50);
    levelRewardText.text = levelReward.ToString();
    levelTextHUD.text = "LEVEL " + currentLevel;
    levelTextEndUI.text = levelTextHUD.text;
    itemCountText.text = totalCoins.ToString();
  }
  public void ReloadScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public IEnumerator IncreaseGold(int multiplier)
  {
    //TODO: Multiply the level reward
    yield return new WaitForSeconds(0.5f);
    int total = totalCoins;

    totalCoins += levelReward * multiplier; //make sure reward is fully applied;

    var rewardDiff = levelReward * (multiplier - 1);

    while (rewardDiff > 0)
    {
      var diff = Math.Min(9, rewardDiff);
      rewardDiff -= diff;
      levelReward += diff;
      levelRewardText.text = levelReward.ToString();
      yield return null;
    }

    yield return new WaitForSeconds(0.5f);

    var count = levelReward;

    while (count > 0)
    {
      var diff = Math.Min(3, count);
      count -= diff;
      total += diff;
      totalCoinsText.text = total.ToString();
      yield return null;
    }
  }

  public void GratifyUser()
  {
    int index = (int)(UnityEngine.Random.Range(0, gratificationTexts.childCount * 29f)) % gratificationTexts.childCount;
    StartCoroutine(ShowGratification(index));
  }

  IEnumerator ShowGratification(int index)
  {
    gratificationTexts.GetChild(index).gameObject.SetActive(true);
    yield return new WaitForSeconds(gratificationDuration);
    gratificationTexts.GetChild(index).gameObject.SetActive(false);
  }
}
