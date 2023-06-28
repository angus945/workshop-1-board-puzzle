using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapManager : MonoBehaviour
{
    [SerializeField] GridMapCreate _gridMapCreate;

    public void ShowWhichIsNotFill()
    {
        List<GameObject> _gridMapCreateTileMap = _gridMapCreate._tilemap;


        for (int i = 0; i < _gridMapCreateTileMap.Count; i++)
        {
            SpriteRenderer _tileMapGetColor = _gridMapCreateTileMap[i].GetComponent<SpriteRenderer>();
            TilesSetting _getGridMapLength=_gridMapCreateTileMap[i].GetComponent<TilesSetting>();

            if (_getGridMapLength.isFill == false)
            {
                _tileMapGetColor.color = Color.green;
            }
            else
            {
                _tileMapGetColor.color = Color.red;
            }
        }
    }
    public void CloseShowingWhichIsNotFill()
    {
        List<GameObject> _gridMapCreateTileMap = _gridMapCreate._tilemap;

        for (int i = 0; i < _gridMapCreateTileMap.Count; i++)
        {
            SpriteRenderer _tileMapGetColor=_gridMapCreateTileMap[i].GetComponent<SpriteRenderer>();

            _tileMapGetColor.color = Color.black;   
        }
    }
}
