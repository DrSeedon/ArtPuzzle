using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] private AllPuzzle _allPuzzle;
    [SerializeField] private GameObject _effectWin;

    private void OnEnable()
    {
        _allPuzzle.On—omplete += FinishLevel;  
    }

    private void OnDisable()
    {
        _allPuzzle.On—omplete -= FinishLevel;
    }

    private void FinishLevel()
    {
        _effectWin.SetActive(true);
    }
}
