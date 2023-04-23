using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class CardController : MonoBehaviour
{
    [SerializeField] GameObject _originalPosition;
    [SerializeField] GameObject _changePositionYPoint;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] GridMapManager _gridMapManager;
    [SerializeField] GridMapCreate _gridMapCreate;
    [SerializeField] List<GameObject> _tile=new List<GameObject>();
    [SerializeField] BoxCollider2D _boxCollider2D;
    Vector3 _offset;
    void OnMouseDown()
    {
        //Vector3 screenToGamePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        //_offset = gameObject.transform.position - screenToGamePoint;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        Vector3 changeWorldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector3 objectClickPosition = changeWorldPoint + _offset;
        this.gameObject.transform.position = changeWorldPoint;
        if (changeWorldPoint.y >= _changePositionYPoint.transform.position.y)
        {
            CloseCardSpriteRender();
            _gridMapManager.ShowWhichIsNotFill();
        }
    }
    private void OnMouseUpAsButton()
    {
        List<int> _record = new List<int>();
        for (int a = 0; a < _tile.Count; a++)
        {
            int _failCount = 0;
            for (int b = 0; b < _gridMapCreate._tilemap.Count; b++)
            {
                if (Vector2.Distance(_tile[a].transform.position, _gridMapCreate._tilemap[b].transform.position) <= 0.5 && _gridMapCreate._tilemap[b].GetComponent<TilesSetting>()._isFill == false)
                {
                    _tile[a].transform.position = _gridMapCreate._tilemap[b].transform.position;
                    _gridMapCreate._tilemap[b].GetComponent<TilesSetting>()._isFill = true;
                    _record.Add(b);
                    break;
                }
                else
                {
                    _failCount++;
                }
            }
            if (_failCount == _gridMapCreate._tilemap.Count)
            {
                for (int i = 0; i < _record.Count; i++)
                {
                    _gridMapCreate._tilemap[_record[i]].GetComponent<TilesSetting>()._isFill = false;
                }
                _spriteRenderer.enabled = true;
                transform.position = _originalPosition.transform.position;
                return;
            }
        }
        Debug.Log(0);
        _boxCollider2D.enabled = false;
    }
    void CloseCardSpriteRender()
    {
        _spriteRenderer.enabled = false;
    }
}
