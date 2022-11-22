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
  Dictionary<string, GameObject> Instructions;
  [SerializeField]
  GameObject endUI;
  [SerializeField]
  GameObject HUD;
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
  [SerializeField]
  TextMeshProUGUI multiplierText;
  [BoxGroup("Texts")]
  [SerializeField]
  TextMeshProUGUI successText;
  [BoxGroup("Texts")]
  public
  TextMeshProUGUI itemCountText;
  [BoxGroup("Texts")]
  [SerializeField]
  TextMeshProUGUI itemTotalText;

  [SerializeField]
  GameObject joystickTutorial;

  [BoxGroup("Visuals")]
  [SerializeField] Image blackout;
  [BoxGroup("Visuals")]
  [SerializeField] GameObject hiddenUI;

  [BoxGroup("Visuals")]
  [SerializeField] Transform icon;

  [BoxGroup("Buttons")]
  [SerializeField]
  GameObject playAgainButton;
  [BoxGroup("Buttons")]
  [SerializeField]
  GameObject nextButton;

  [BoxGroup("Coins")]
  [SerializeField]
  GameObject rewardCoinGroup;

  InputField levelInput;
  int hiddenMenuCount;

  public delegate TextMeshProUGUI OnGetCurrentMoneyText();
  public static OnGetCurrentMoneyText onGetMoneyText;
  public delegate Transform OnGetMoneyIcon();
  public static OnGetMoneyIcon onGetMoneyIcon;
  private void Awake()
  {
    currentLevel = GameManager.Instance.currentLevel;
    totalCoins = GameManager.Instance.totalCoins;
    completedTutorial = GameManager.Instance.completedTutorial;
    levelInput = transform.GetChild(5).GetChild(1).GetComponent<InputField>();
    hiddenMenuCount = 0;
    //Debug.Log("CurrentLevel: " + currentLevel);
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
  // Start is called before the first frame update
  void Start()
  {
    levelReward = UnityEngine.Random.Range(20, 50);
    levelRewardText.text = levelReward.ToString();
    levelTextHUD.text = "LEVEL " + currentLevel;
    levelTextEndUI.text = levelTextHUD.text;
    itemCountText.text = totalCoins.ToString();
    hiddenMenuCount = 0;
  }

  public void Success(int multiplier)
  {
    if (!completedTutorial)
    {
      completedTutorial = true;
    }
    playAgainButton.SetActive(false);
    nextButton.SetActive(true);
    rewardCoinGroup.SetActive(true);
    successText.text = "SUCCESS";
    multiplierText.text = "x" + multiplier;
    endUI.SetActive(true);
    HUD.SetActive(false);
    StartCoroutine(IncreaseGold(multiplier));
  }

  public void Fail()
  {
    playAgainButton.SetActive(true);
    nextButton.SetActive(false);
    rewardCoinGroup.SetActive(false);
    successText.text = "TRY AGAIN";
    HUD.SetActive(false);
    endUI.SetActive(true);
  }

  public void ReloadScene()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void NextScene()
  {
    //Debug.Log("NextScene");
    nextButton.SetActive(false);
    GameManager.Instance.currentLevel++;
    GameManager.Instance.totalCoins = totalCoins;
    GameManager.Instance.completedTutorial = completedTutorial;
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

  public void DisableJoystickTutorial()
  {
    joystickTutorial.SetActive(false);
  }

  public void EnableJoystickTutorial()
  {
    joystickTutorial.SetActive(true);
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

  public void hiddenMenuPress()
  {
    StartCoroutine(HiddenMenuAction());
  }

  public void SkipToLevel()
  {
    currentLevel = Int16.Parse(levelInput.text) - 1;
    NextScene();
  }

  IEnumerator HiddenMenuAction()
  {
    hiddenMenuCount++;
    if (hiddenMenuCount == 3)
    {
      hiddenUI.SetActive(true);
      yield return null;
    }
    else
    {
      yield return new WaitForSeconds(1);
      hiddenMenuCount--;
    }
  }
}
