using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CardShapeCreate))]
public class CardController : MonoBehaviour
{
    [SerializeField] GameObject _changePositionYPoint;
    [SerializeField] GameObject _trigger;
    [SerializeField] GameObject _card;
    [SerializeField] List<GameObject> _tile=new List<GameObject>();
    [SerializeField] CardShapeCreate _cardShapeCreate;
    [SerializeField] BoxCollider2D _boxCollider2D;

    //reference
    public CardScirptObject _layout;
    public GameObject _originalPosition;
    public GridMapManager _gridMapManager;
    public GridMapCreate _gridMapCreate;
    public TIleMapManger _tileMapManger;


    private void Start()
    {
        
        _tile = _cardShapeCreate.GetCardDateAndCreate(_layout);
        for (int i = 0; i < _tile.Count; i++)
        {
            _tile[i].transform.SetParent(this.transform);
            //if (_layout.GetWhereIsTrigger() == i)
            //{
            //    _trigger = Instantiate(_trigger,new Vector2(0,0), Quaternion.identity);
            //    _trigger.transform.SetParent(_tile[i].transform);
            //}
            _tile[i].transform.localPosition = _layout.GetCardLayOutPosition(i);
            _tile[i].SetActive(false);
        }
    }

    void OnMouseDown()
    {
        //Vector3 screenToGamePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        //_offset = gameObject.transform.position - screenToGamePoint;
    }

    void OnMouseDrag()
    {
        MouseClickDrag();
    }
    private void OnMouseUpAsButton()
    {
        MouseDropTile();
    }


    private void MouseDropTile()
    {
        List<int> _record = new List<int>();
        bool _failIsTrue = false;
        for (int a = 0; a < _tile.Count; a++)
        { 
            bool _isFail = CheckAndPutIn(_record ,a);
            if (_isFail)
            {
                PutBackIfFail(_record, _isFail, ref _failIsTrue);
            }
        }
        if (!_failIsTrue)
        {
            _boxCollider2D.enabled = false;
            if (_tileMapManger.TileIsFull())
            {
                _tileMapManger.GameEnd();
            }
            //CheckAndSetTrigger();
        }
        _gridMapManager.CloseShowingWhichIsNotFill();
    }

    private void PutBackIfFail(List<int> _recordNumber, bool isFail, ref bool failisture)
    {
        if (isFail)
        {
            for (int i = 0; i < _recordNumber.Count; i++)
            {
                int _tileRecord = _recordNumber[i];
                _gridMapCreate._tilemap[_tileRecord].GetComponent<TilesSetting>().isFill = false;
            }
            _card.SetActive(true);
            for (int i = 0; i < _tile.Count; i++)
            {
                _tile[i].SetActive(false);
            }
            this.transform.position = _originalPosition.transform.position;
            failisture = true;
        }
    }

    private bool CheckAndPutIn(List<int> _recordNumber,int loopNumber)
    {
        int _failCountNum = 0;
        for (int b = 0; b < _gridMapCreate._tilemap.Count; b++)
        {
            TilesSetting _whichTileMap = _gridMapCreate._tilemap[b].GetComponent<TilesSetting>();
            float _tileDistance = Vector2.Distance(_tile[loopNumber].transform.position, _whichTileMap.transform.position);
            bool _checkTileFill = _whichTileMap.isFill;
            if (_tileDistance <= 0.5 && !_checkTileFill)
            {
                _tile[loopNumber].transform.position = _whichTileMap.transform.position;
                _whichTileMap.isFill = true;

                _recordNumber.Add(b);
                break;
            }
            else
            {
                _failCountNum++;
            }
        }

        return _failCountNum == _gridMapCreate._tilemap.Count;
    }

    private void CheckAndSetTrigger()
    {
        for (int i = 0; i < _tile.Count; i++)
        {
            Transform _tileGetTransform = _tile[i].GetComponent<Transform>();
            foreach (Transform child in _tileGetTransform)
            {
                if (child.tag == "Trigger")
                {
                    SpriteRenderer _changeColor = _tileGetTransform.GetComponent<SpriteRenderer>();
                    _changeColor.color = Color.cyan;

                    for(int b = 0; b < _gridMapCreate._tilemap.Count; b++)
                    {
                        TilesSetting _whichTileMap = _gridMapCreate._tilemap[b].GetComponent<TilesSetting>();
                        float _tileDistance = Vector2.Distance(_tileGetTransform.transform.position, _whichTileMap.transform.position);
                        bool _checkTileFill = _whichTileMap.isFill;
                        if (_tileDistance <= 0.5 && _checkTileFill)
                        {

                            _tile[i].transform.position = _whichTileMap.transform.position;
                            _trigger.transform.SetParent(_whichTileMap.transform);
                            _whichTileMap.isFill = false;
                            break;
                        }
                    }
                }
            }
        }
    }

    void MouseClickDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        Vector3 changeWorldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        this.gameObject.transform.position = changeWorldPoint;
        if (changeWorldPoint.y >= _changePositionYPoint.transform.position.y)
        {
            _card.SetActive(false);
            _gridMapManager.ShowWhichIsNotFill();
            for (int i = 0; i < _tile.Count; i++)
            {
                _tile[i].SetActive(true);
            }
        }
    }
}
