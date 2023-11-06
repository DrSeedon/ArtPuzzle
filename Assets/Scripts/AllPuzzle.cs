using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AllPuzzle : MonoBehaviour
{
    public int _currentNumber = 1;

    public List<MovementPuzzle> _allPuzzleList = new List<MovementPuzzle>();

    public Action OnComplete; 

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            MovementPuzzle element = transform.GetChild(i).gameObject.GetComponent<MovementPuzzle>();
            if (element != null)
            {
                _allPuzzleList.Add(element);
                element.OnJoined += FindElemets;
            }
        }

        TryFindElementsWithDesiredNumber();
    }

    public void FindElemets(MovementPuzzle puzzle)
    {
        RemoveDeletedElements(puzzle);

        if(_allPuzzleList.Count==0)
        {
            OnComplete?.Invoke();
            return;
        }

        if (TryFindElementsWithDesiredNumber()==false)
        {
            _currentNumber++;
            TryFindElementsWithDesiredNumber();
        }
    }

    private bool TryFindElementsWithDesiredNumber()
    {
        bool isFind=false;

        foreach (MovementPuzzle _element in _allPuzzleList)
        {
            if (_element.Number == _currentNumber)
            {
                _element.MakeActive();
                isFind = true;
            }
        }
        return isFind;
    }

    private void RemoveDeletedElements(MovementPuzzle puzzle)
    {
        _allPuzzleList.RemoveAll(p => p == puzzle);
    }

}
        
