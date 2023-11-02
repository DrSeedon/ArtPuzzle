using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePuzzle : MonoBehaviour
{
    [SerializeField] private GameObject _form;         
    [SerializeField] private WinGame _winGame;
    [SerializeField] private GameObject _content;
    [SerializeField] private int _number;

    private bool _isFinish;       //Перенести в другой скрипт
    private bool _isMove;
    private bool _isActive;
    private BoxCollider2D _boxCollider;
    private Vector2 _startPositionElem;

    public bool IsFinish=> _isFinish;
    public int Number => _number;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (_isMove && _isFinish==false)
        {
            Move();
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Размер " + _startPositionElem);
            _startPositionElem = transform.position;
            gameObject. transform.SetParent(null);
            _isMove = true;
        }
    }

    private void OnMouseUp()
    {
        PutInNewPositionElem();
        
        _isMove = false;
    }

    private void Move()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    private void PutInNewPositionElem()
    {

        if (Vector3.Distance(transform.position, _form.transform.position) <= 2)
        {
            transform.position = _form.transform.position;

            _winGame.AddConnectElement();
            _boxCollider.enabled = false;

            _isFinish = true;
        }
        else
        {
            transform.SetParent(_content.transform);
            transform.position = _startPositionElem;
        }
    }

    public void ChangeStatus()
    {
        _isActive = true;
    }
}
