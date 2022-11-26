using System;

[Serializable]
class SaveData
{
  public int currentLevel;
  public int currentLevelTxt;
  public int totalCoins;
  public bool completedTutorial;

  public int hearthUpgradeCost;
  public int incomeCots;
  public int speedCost;
  public int mergeCost;

  public int hearthButtonClicked;
  public int incomeButtonClicked;
  public int speedButtonClicked;
  public int mergeButtonClicked;

  public int IncomeIndexMultiplier;
  public int tutorialTextToShown;
}
