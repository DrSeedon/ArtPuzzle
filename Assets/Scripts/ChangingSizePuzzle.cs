using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSizePuzzle : MonoBehaviour
{
    [SerializeField] GameObject _desiredScale; 

    private MovePuzzle _movePuzzle;
    private Vector3 originalScale;

    private void Start()
    {
        _movePuzzle = GetComponent<MovePuzzle>();
        originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        transform.localScale =_desiredScale.transform.localScale;
    }

    private void OnMouseUp()
    {
        if (_movePuzzle.IsFinish== false)
        {
            transform.localScale = originalScale;
        }
    }
}
