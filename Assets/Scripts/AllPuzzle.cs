using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AllPuzzle : MonoBehaviour
{
    private int _currentNumber = 1;

    private List<MovementPuzzle> _allPuzzleList = new List<MovementPuzzle>();

    public Action On—omplete;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            MovementPuzzle _element = transform.GetChild(i).gameObject.GetComponent<MovementPuzzle>();
            _allPuzzleList.Add(_element);
            _allPuzzleList[i].OnJoined += FindElemets;
        }

        TryFindElementsWithDesiredNumber();
    }

    public void FindElemets(MovementPuzzle puzzle)
    {
        RemoveDeletedElements(puzzle);

        if(_allPuzzleList.Count==0)
        {
            On—omplete?.Invoke();
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
        foreach (MovementPuzzle _element in _allPuzzleList)
        {
            if(_element == puzzle)
            {
               _allPuzzleList.Remove(puzzle);
            }
        }
    }
}
        
