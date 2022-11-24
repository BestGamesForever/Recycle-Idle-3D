using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractableCheck : MonoBehaviour
{

  public PutChildInList firstButtonlistOfImagesAndTextMeshes;
  public PutChildInList secondButtonlistOfImagesAndTextMeshes;
  public PutChildInList thirdButtonlistOfImagesAndTextMeshes;
  public PutChildInList fourthButtonlistOfImagesAndTextMeshes;//MergeButton

  private void OnEnable()
  {
    EventManager.onButtonCheck += ButtonInteractableChecks;
  }

  private void Disable()
  {
    EventManager.onButtonCheck -= ButtonInteractableChecks;
  }

  public Button[] skillButtons; //0 mana 1 talent 2 speed
  int newCarCost;
  int incomeCost;
  int newRoadCost;
  int mergeCost;

  void ButtonInteractableChecks()
  {
    newCarCost = GameManager.Instance.newCarCost;
    incomeCost = GameManager.Instance.incomeCots;
    newRoadCost = GameManager.Instance.newRoadCost;
    mergeCost = GameManager.Instance.mergeCost;
    int totalcoin = GameManager.Instance.totalCoins;

    if (newCarCost > totalcoin)
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
    if (incomeCost > totalcoin)
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
    if (newRoadCost > totalcoin)
    {
      if (skillButtons[2] != null)
      {
        skillButtons[2].interactable = false;
        thirdButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

      }
    }
    else
    {
      if (skillButtons[2] != null)
      {
        skillButtons[2].interactable = true;
        thirdButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);

      }
    }
    if (newRoadCost > totalcoin)
    {
      MerheButtonInteractability();
    }
  }

  public void CheckMergeButtonWhenReachThreeCars(int listCounts)
  {

    if (listCounts < 3)
    {
      skillButtons[3].gameObject.SetActive(false);
    }
    else
    {
      skillButtons[3].gameObject.SetActive(true);
    }

  }

  void MerheButtonInteractability()
  {
    if (skillButtons[3] != null)
    {
      {
        skillButtons[3].interactable = false;
        fourthButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

      }
    }
    else
    {
      if (skillButtons[3] != null)
      {
        skillButtons[3].interactable = true;
        fourthButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);

      }
    }
  }
}
