using UnityEngine;
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
  public int totalCoins = 1000000;

  [ReadOnly]
  public bool completedTutorial = false;

  [ReadOnly]
  public int newCarCost = 200;

  [ReadOnly]
  public int incomeCots = 200;

  [ReadOnly]
  public int newRoadCost = 200;
  [ReadOnly]
  public int mergeCost = 200;

  [ReadOnly]
  public int addCarButtonClicked = 1;

  [ReadOnly]
  public int incomeButtonClicked = 1;

  [ReadOnly]
  public int addRoadButtonClicked = 1;
  [ReadOnly]
  public int mergeButtonClicked = 1;

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
  private void Update()
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

    saveData.hearthUpgradeCost = newCarCost;
    saveData.incomeCots = incomeCots;
    saveData.speedCost = newRoadCost;
    saveData.mergeCost = mergeCost;

    saveData.hearthButtonClicked = addCarButtonClicked;
    saveData.incomeButtonClicked = incomeButtonClicked;
    saveData.speedButtonClicked = addRoadButtonClicked;
    saveData.mergeButtonClicked = mergeButtonClicked;


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

    newCarCost = saveData.hearthUpgradeCost;
    incomeCots = saveData.incomeCots;
    newRoadCost = saveData.speedCost;
    mergeCost = saveData.mergeCost;

    addCarButtonClicked = saveData.hearthButtonClicked;
    incomeButtonClicked = saveData.incomeButtonClicked;
    addRoadButtonClicked = saveData.speedButtonClicked;
    mergeButtonClicked = saveData.mergeButtonClicked;

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
