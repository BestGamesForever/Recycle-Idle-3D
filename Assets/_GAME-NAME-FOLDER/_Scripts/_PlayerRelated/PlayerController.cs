using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static GameState _gameState;
    //GENERAL-COMPONENT PROPERTIES
    CharacterController _controller;
    PlayerAction player;
    public List<GameObject> _dwarfs;
    [SerializeField] Transform model;
    [SerializeField] Animator _anim;
    //SERILIZEFIELD PROPERTIES
    [TabGroup("Taps", "Movement")]
   public float _forwardSpeed;
    [TabGroup("Taps", "Movement")]
    [SerializeField] float _sideMoveSpeed;
    [TabGroup("Taps", "Movement")]
    [SerializeField] float _strafeSpeed;
    [TabGroup("Taps", "Movement")]
    [SerializeField] float yRotateLimit;

    [SerializeField] GameObject TapToMove;
    //BOOL PROPERTIES  
    public static bool activateInput;
    bool _isDwarf;
    //FLOAT PROPERTIES
    [SerializeField] float leftXClamp;
    [SerializeField] float rightXClamp;
    //VECTOR PROPERTIES   
    Vector3 _leanStartVector;
    Vector3 _leanEndVector;
    private Vector3 velocity;
    bool iscam;
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
        iscam = false;
        transform.Translate(transform.forward * 5 * Time.deltaTime);
        _gameState = GameState.None;
        _controller = GetComponent<CharacterController>();
        player.Movement.TouchPress.started += _ => TouchStart();
        player.Movement.TouchPress.canceled += _ => TouchEnd();
        velocity = Vector3.zero;
        Invoke("IsCam", 3);
    }
    void IsCam()
    {
        iscam = true;
    }
    private void TouchStart()
    {
        if (!iscam)
        {
            return;
        }
        if (_gameState != GameState.End && _gameState != GameState.Fail)
        {
            activateInput = true;
            _gameState = GameState.Run;
            TapToMove.SetActive(false);
            _anim.Play("_startGame");
        }
    }
    private void TouchEnd()
    {
        if (_gameState != GameState.End)
        {
            //activateInput = false;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }
    void Update()
    {
        if (_gameState == GameState.Run)
        {
            if (_gameState == GameState.Fail)
            {
                return;
            }
            velocity.y += -9.81f * Time.deltaTime;
            _controller.Move(velocity * Time.deltaTime);
            float rotation;
            if (activateInput)
            {
                float strafeDelta = player.Movement.Delta.ReadValue<Vector2>().x;
                _controller.Move(transform.right * strafeDelta * _strafeSpeed * Time.deltaTime);

                if (strafeDelta == 0)
                {
                    rotation = model.localRotation.eulerAngles.y;
                    if (rotation != 0)
                    {
                        var fixAmount = yRotateLimit * Time.deltaTime;
                        if (rotation < 180) fixAmount *= -1;
                        model.Rotate(0, fixAmount, 0);
                    }
                }
                else
                {
                    model.Rotate(0, strafeDelta * yRotateLimit * Time.deltaTime, 0);
                    rotation = model.localRotation.eulerAngles.y;

                    if (rotation > 180) rotation -= 360;
                    model.localRotation = Quaternion.Euler(model.localRotation.eulerAngles.x, Mathf.Clamp(rotation, -yRotateLimit, yRotateLimit), model.localRotation.eulerAngles.z);
                }
            }
            else
            {
                rotation = model.localRotation.eulerAngles.y;
                if (rotation != 0)
                {
                    var fixAmount = yRotateLimit * Time.deltaTime;
                    if (rotation < 180) fixAmount *= -1;

                    model.Rotate(0, fixAmount, 0);
                }
            }
            if (activateInput)
            {
                _controller.Move(transform.forward * _forwardSpeed * Time.deltaTime);
                var position = transform.position;
                position.x = Mathf.Clamp(position.x, leftXClamp, rightXClamp);
                transform.position = position;
                _anim.Play("_startGame");
                for (int i = 0; i < _dwarfs.Count; i++)
                {
                    if (_dwarfs[i].activeSelf)
                    {
                        _dwarfs[i].GetComponent<Animator>().Play("StickManRunning");
                    }
                }
            }
            else
            {
                _anim.Play("Idle");
                for (int i = 0; i < _dwarfs.Count; i++)
                {
                    if (_dwarfs[i].activeSelf)
                    {
                        _dwarfs[i].GetComponent<Animator>().Play("Idle");
                    }
                }
            }
        }
    }   
}
