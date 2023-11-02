using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject _allPuzzleElem;
    [SerializeField] private GameObject _panelPuzzle;
    [SerializeField] private GameObject _winEffect;

    private int _fullElement;
    private int _connectedElement;

    private void Start()
    {
        _fullElement = _allPuzzleElem.transform.childCount;
    }

    private void Update()
    {
        if(_fullElement== _connectedElement)
        {
            _winEffect.SetActive(true);
        }
    }

    public void AddConnectElement()
    {
        _connectedElement++;
    }
}
