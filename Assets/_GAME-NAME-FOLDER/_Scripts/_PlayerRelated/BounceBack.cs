using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    [SerializeField] float _dwarfSpeed;
    public GameObject[] childs;
    public static bool isbounce;
    float timer;
    private void Start()
    {
        timer = .5f;
    }
    private void Update()
    {
        if (PlayerController._gameState == GameState.Fail)
        {
            return;
        }
        if (PlayerController._gameState == GameState.Bounce )
        {
            Debug.Log("Bounce");            
            transform.Translate(Vector3.forward * _dwarfSpeed * Time.deltaTime);
            timer -=Time.deltaTime;
            if (timer<=0)
            {
                PlayerController._gameState = GameState.Run;
                timer = .5f;
            }           
        }
    }  
}
