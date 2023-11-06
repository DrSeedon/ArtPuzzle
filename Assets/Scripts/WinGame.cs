using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private AllPuzzle _allPuzzle;
    [SerializeField] private GameObject _effectWin;

    private void OnEnable()
    {
        _allPuzzle.OnComplete += FinishLevel;  
    }

    private void OnDisable()
    {
        _allPuzzle.OnComplete -= FinishLevel;
    }

    private void FinishLevel()
    {
        _effectWin.SetActive(true);
    }
}
