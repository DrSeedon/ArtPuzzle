using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSizePuzzle : MonoBehaviour
{
    [SerializeField] GameObject _desiredScale;

    private MovementPuzzle _movePuzzle;


    private void OnEnable()
    {
        _movePuzzle = GetComponent<MovementPuzzle>();

        _movePuzzle.OnCreateElementCopy += IncreaseSize;
    }

    private void OnDisable()
    {
        _movePuzzle.OnCreateElementCopy -= IncreaseSize;
    }

    private void IncreaseSize(MovementPuzzle puzzle)
    {
        puzzle.transform.localScale = _desiredScale.transform.localScale;
    }
}
