using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCollectingPuzzles : MonoBehaviour
{
    private int _currentNumberElement=0;
    private List<MovePuzzle> _elementsPuzzle = new List<MovePuzzle>();

    private void Start()
    {
        FillingList();
    }

    private void FillingList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            MovePuzzle _element = transform.GetChild(i).gameObject.GetComponent<MovePuzzle>();
            _elementsPuzzle.Add(_element);

            if(MakeActive()==false)
                _currentNumberElement++;
        }
    }

    private bool MakeActive()
    {
        bool _isFind=false;

        foreach (MovePuzzle element in _elementsPuzzle)
        {
            if(element.Number== _currentNumberElement)
            {
                element.ChangeStatus();
                _isFind=true;
            }
        }
        return _isFind;
    }
}
