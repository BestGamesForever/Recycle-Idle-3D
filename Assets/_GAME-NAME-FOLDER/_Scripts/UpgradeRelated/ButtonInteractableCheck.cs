using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractableCheck : MonoBehaviour
{

  public PutChildInList firstButtonlistOfImagesAndTextMeshes;
  public PutChildInList secondButtonlistOfImagesAndTextMeshes;
  public PutChildInList thirdirstButtonlistOfImagesAndTextMeshes;
  private void OnEnable()
  {
    EventManager.onButtonCheck += ButtonInteractableChecks;
  }

  private void Disable()
  {
    EventManager.onButtonCheck -= ButtonInteractableChecks;
  }

  public Button[] skillButtons; //0 mana 1 talent 2 speed
  int hearthUpgradeCost;
  int incomeValue;
  int speedValue;

  void ButtonInteractableChecks()
  {
    hearthUpgradeCost = GameManager.Instance.hearthUpgradeCost;
    incomeValue = GameManager.Instance.incomeCots;
    speedValue = GameManager.Instance.speedCost;
    int totalcoin = GameManager.Instance.totalCoins;
    if (hearthUpgradeCost > totalcoin)
    {
      if (skillButtons[0] != null)
      {
        skillButtons[0].interactable = false;
        firstButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

      }
    }
    else
    {
      if (skillButtons[0] != null)
      {
        skillButtons[0].interactable = true;
        firstButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);

      }
    }
    if (incomeValue > totalcoin)
    {
      if (skillButtons[1] != null)
      {
        skillButtons[1].interactable = false;
        secondButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

      }
    }
    else
    {
      if (skillButtons[1] != null)
      {
        skillButtons[1].interactable = true;
        secondButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);

      }
    }
    if (speedValue > totalcoin)
    {
      if (skillButtons[2] != null)
      {
        skillButtons[2].interactable = false;
        thirdirstButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

      }
    }
    else
    {
      if (skillButtons[2] != null)
      {
        skillButtons[2].interactable = true;
        thirdirstButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);

      }
    }
  }
}
