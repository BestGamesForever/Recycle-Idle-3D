using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPlacement : MonoBehaviour
{
    public GameObject _money;
    public List<Transform> _moneyInsideThis;
    public Vector3[] _positions;

    private void Start()
    {
        _moneyInsideThis = new List<Transform>();
        for (int i = 0; i < _positions.Length; i++)
        {
            GameObject money = Instantiate(_money,transform);
            _moneyInsideThis.Add(money.transform);

        }
        for (int i = 0; i < _moneyInsideThis.Count; i++)
        {
            _moneyInsideThis[i].transform.position = _positions[i];
          
        }
    }
}
