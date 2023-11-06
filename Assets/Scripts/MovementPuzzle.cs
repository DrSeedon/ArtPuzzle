using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject _form;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private WinGame _winGame;
    [SerializeField] private int _number;

    private MovementPuzzle _elementCopy;

    private bool _isMove;
    private bool _isActive;
    private BoxCollider2D _boxCollider;

    public Action <MovementPuzzle> OnCreateElementCopy ;
    public Action<MovementPuzzle> OnJoined;

    public int Number => _number;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (_isMove)
        {
            Move();
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _elementCopy= Instantiate(gameObject, _canvas.transform).GetComponent<MovementPuzzle>();

            OnCreateElementCopy?.Invoke(_elementCopy);
            gameObject.GetComponent<Image>().enabled = false;

            _isMove = true;
        }
    }

    private void OnMouseUp()
    {
        _isMove = false;
        Destroy(_elementCopy.gameObject);
        gameObject.GetComponent<Image>().enabled = true;
    }

    public void MakeActive()
    {
        _isActive= true;
    }

    private void Move()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _elementCopy.transform.position = mousePosition;

        PutInNewPositionElem();
    }

    private void PutInNewPositionElem()
    {
        //print(Vector3.Distance(_elementCopy.transform.position, _form.transform.position));


        if (Vector3.Distance(_elementCopy.transform.position, _form.transform.position) <= 90.001f && _isActive)
        {
            _elementCopy.transform.position = _form.transform.position;
            _elementCopy.GetComponent<BoxCollider2D>().enabled = false;

            OnJoined?.Invoke(this);
            Destroy(gameObject);
            print("1");
        }
    }


}
