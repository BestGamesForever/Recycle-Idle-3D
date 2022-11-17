using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Putchildinlist : MonoBehaviour
{
    //For Player Animations....
    public static List<Transform> _animList;
    public List<Transform> _show;
    //  ----------------------------------------------
    //For Trees
    public static List<Transform> _treeList;
    public List<Transform> _showTree;

    //For Axes
    public static List<Transform> _axeList;
    void Start()
    {
        _axeList = new List<Transform>();
        if (gameObject.name == "Player")
        {
            _show = new List<Transform>();
            _animList = new List<Transform>();
            _show.Add(transform.GetChild(0).transform);
            _animList.Add(transform.GetChild(0).transform);

        }
        if (gameObject.name == "Trees")
        {
            _showTree = new List<Transform>();
            _treeList = new List<Transform>();
            foreach (Transform _treechilds in transform)
            {
                _showTree.Add(_treechilds);
                _treeList.Add(_treechilds);
            }
        }
    }
}
