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
  Image[] greenSidesImage;

  private void OnEnable()
  {
    greenSidesImage = new Image[skillButtons.Length];
    for (int i = 0; i < skillButtons.Length; i++)
    {
      greenSidesImage[i] = skillButtons[i].transform.GetChild(0).GetComponent<Image>();
    }
    EventManager.onButtonCheck += ButtonInteractableChecks;

  }

  private void Disable()
  {
    EventManager.onButtonCheck -= ButtonInteractableChecks;
  }

  public Button[] skillButtons; //
  int newCarCost;
  int incomeCost;
  int newRoadCost;
  int mergeCost;

  int addIncomeClicked;

  void ButtonInteractableChecks()
  {
    newCarCost = GameManager.Instance.newCarCost;
    incomeCost = GameManager.Instance.incomeCots;
    newRoadCost = GameManager.Instance.newRoadCost;
    mergeCost = GameManager.Instance.mergeCost;
    addIncomeClicked = GameManager.Instance.incomeButtonClicked;
    int totalcoin = GameManager.Instance.totalCoins;

    if (newCarCost > totalcoin)
    {
      if (skillButtons[0] != null)
      {
        skillButtons[0].interactable = false;
        greenSidesImage[0].enabled = false;
        firstButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

      }
    }
    else
    {
      if (skillButtons[0] != null)
      {
        skillButtons[0].interactable = true;
        greenSidesImage[0].enabled = true;
        firstButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);

      }
    }
    if (incomeCost > totalcoin)
    {
      if (skillButtons[1] != null)
      {
        skillButtons[1].interactable = false;
        greenSidesImage[1].enabled = false;
        secondButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

      }
    }
    else
    {
      Debug.Log($"Pass  {gameObject}");
      if (skillButtons[1] != null)
      {
        skillButtons[1].interactable = true;
        greenSidesImage[1].enabled = true;
        secondButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);
      }
      if (addIncomeClicked == CheckPointsToFind.checkPointsAtStart.Count - 1)
      {
        AddIncomeReachMax();
      }
    }
    if (newRoadCost > totalcoin)
    {
      if (skillButtons[2] != null)
      {
        skillButtons[2].interactable = false;
        greenSidesImage[2].enabled = false;
        thirdButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

      }
    }
    else
    {
      if (skillButtons[2] != null)
      {
        skillButtons[2].interactable = true;
        greenSidesImage[2].enabled = true;
        thirdButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);

      }
    }
    if (newRoadCost > totalcoin)
    {
      if (skillButtons[3] != null)
      {
        {
          skillButtons[3].interactable = false;
          greenSidesImage[3].enabled = false;
          fourthButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

        }
      }
      else
      {
        if (skillButtons[3] != null)
        {
          skillButtons[3].interactable = true;
          greenSidesImage[3].enabled = true;
          fourthButtonlistOfImagesAndTextMeshes.AlphaOnandOff(true);

        }
      }
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

  void ButtonInteractability()
  {

  }

  public void AddIncomeReachMax()
  {
    Debug.Log($"PassNow  {gameObject}");
    skillButtons[1].interactable = false;
    greenSidesImage[1].enabled = false;
    secondButtonlistOfImagesAndTextMeshes.AlphaOnandOff(false);

  }
}
