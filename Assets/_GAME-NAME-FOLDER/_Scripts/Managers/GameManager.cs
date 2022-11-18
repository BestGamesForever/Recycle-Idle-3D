using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GameAnalyticsSDK;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class GameManager : Singleton<GameManager>
{
  [ReadOnly]
  public int currentLevel = 1;
  [ReadOnly]
  public int currentLevelTxt = 1;

  [ReadOnly]
  public int totalCoins = 300;

  [ReadOnly]
  public bool completedTutorial = false;

  [ReadOnly]
  public int hearthAmount = 3;

  [ReadOnly]
  public int IncomeAmount = 20;

  [ReadOnly]
  public float SpeedAmount = .1f;

  [ReadOnly]
  public int hearthCooldownSpeed = 1;

  [ReadOnly]
  public int talentCooldownSpeed = 1;

  [ReadOnly]
  public int experienceCooldownSpeed = 1;

  [ReadOnly]
  public int hearthUpgradeCost = 200;

  [ReadOnly]
  public int incomeCots = 200;

  [ReadOnly]
  public int speedCost = 200;

  [ReadOnly]
  public int hearthButtonClicked = 1;

  [ReadOnly]
  public int incomeButtonClicked = 1;

  [ReadOnly]
  public int speedButtonClicked = 1;

  [ReadOnly]
  public int IncomeIndexMultiplier = 10;
  [ReadOnly]
  public int tutorialTextToShown = 0;

  SaveData saveData = new SaveData();

  void Awake()
  {
    DontDestroyOnLoad(this);
    LoadState();
  }

  private void OnDestroy()
  {
    SaveState();
  }

  public void SaveState()
  {
    string filePath = Application.persistentDataPath + "/saveFile.art";

    saveData.currentLevel = currentLevel;
    saveData.currentLevelTxt = currentLevelTxt;
    saveData.totalCoins = totalCoins;
    saveData.completedTutorial = completedTutorial;

    saveData.tapAmount = hearthAmount;
    saveData.IncomeAmount = IncomeAmount;
    saveData.SpeedAmount = SpeedAmount;

    saveData.hearthCooldownSpeed = hearthCooldownSpeed;
    saveData.talentCooldownSpeed = talentCooldownSpeed;
    saveData.experienceCooldownSpeed = experienceCooldownSpeed;

    saveData.hearthUpgradeCost = hearthUpgradeCost;
    saveData.incomeCots = incomeCots;
    saveData.speedCost = speedCost;

    saveData.hearthButtonClicked = hearthButtonClicked;
    saveData.incomeButtonClicked = incomeButtonClicked;
    saveData.speedButtonClicked = speedButtonClicked;
    saveData.IncomeIndexMultiplier = IncomeIndexMultiplier;

    saveData.tutorialTextToShown = tutorialTextToShown;

    byte[] bytes = SerializationUtility.SerializeValue(saveData, DataFormat.Binary);
    File.WriteAllBytes(filePath, bytes);
  }

  public void LoadState()
  {
    string filePath = Application.persistentDataPath + "/saveFile.art";
    if (!File.Exists(filePath))
      return; // No state to load

    byte[] bytes = File.ReadAllBytes(filePath);
    saveData = SerializationUtility.DeserializeValue<SaveData>(bytes, DataFormat.Binary);

    currentLevel = saveData.currentLevel;
    currentLevelTxt = saveData.currentLevelTxt;
    totalCoins = saveData.totalCoins;
    completedTutorial = saveData.completedTutorial;

    hearthAmount = saveData.tapAmount;
    IncomeAmount = saveData.IncomeAmount;
    SpeedAmount = saveData.SpeedAmount;

    hearthCooldownSpeed = saveData.hearthCooldownSpeed;
    talentCooldownSpeed = saveData.talentCooldownSpeed;
    experienceCooldownSpeed = saveData.experienceCooldownSpeed;

    hearthUpgradeCost = saveData.hearthUpgradeCost;
    incomeCots = saveData.incomeCots;
    speedCost = saveData.speedCost;

    hearthButtonClicked = saveData.hearthButtonClicked;
    incomeButtonClicked = saveData.incomeButtonClicked;
    speedButtonClicked = saveData.speedButtonClicked;

    IncomeIndexMultiplier = saveData.IncomeIndexMultiplier;

    tutorialTextToShown = saveData.tutorialTextToShown;
  }

  [Button]
  public void ClearState()
  {
    string filePath = Application.persistentDataPath + "/saveFile.art";
    if (!File.Exists(filePath))
      return; // No state to clear

    File.Delete(filePath);
  }
}
