using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
  public static GameState _gameState;
  //GENERAL-COMPONENT PROPERTIES  
  PlayerAction player;
  [SerializeField] GameObject TapToMove;
  //BOOL PROPERTIES  
  bool activateInput;
  float timer;
  private void OnEnable()
  {
    player.Enable();
  }
  private void OnDisable()
  {
    player.Disable();
  }
  private void Awake()
  {
    player = new PlayerAction();

  }
  void Start()
  {
    activateInput = false;
    _gameState = GameState.None;
    player.Movement.TouchPress.started += _ => TouchStart();
    player.Movement.TouchPress.performed += _ => TouchEnd();
  }

  private void TouchStart()
  {

    if (isPointerOverUI())
    {
      return;
    }
    if (_gameState != GameState.End && _gameState != GameState.Fail)
    {
      timer = .5f;
      _gameState = GameState.Run;

    }

  }
  private void TouchEnd()
  {
    if (!activateInput)
    {
      activateInput = true;
      TapToMove.SetActive(false);
    }
  }
  void Update()
  {
    timer -= Time.deltaTime;
    if (timer <= 0)
    {
      _gameState = GameState.None;
    }
  }
  private bool isPointerOverUI()
  {
    PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);
    eventDataPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    List<RaycastResult> results = new List<RaycastResult>();
    EventSystem.current.RaycastAll(eventDataPosition, results);
    for (int i = 0; i < results.Count; i++)
    {
      Debug.Log($"GameObject  {results[i].gameObject.name}");
    }
    return results.Count > 0;
  }
}
