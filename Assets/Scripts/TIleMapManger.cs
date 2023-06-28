using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleMapManger : MonoBehaviour
{
    [SerializeField] GridMapCreate _gridMapCreate;
    private int _currentAllTile;

    public bool TileIsFull()
    {
        for (int i = 0; i < _gridMapCreate._tilemap.Count; i++)
        {
            TilesSetting _allTileCheck = _gridMapCreate._tilemap[i].GetComponent<TilesSetting>();
            if (_allTileCheck.isFill)
            {
                _currentAllTile++;
                Debug.Log(_currentAllTile);
                if (_currentAllTile == _gridMapCreate._tilemap.Count)
                {
                    return true;
                }
            }
        }
        _currentAllTile = 0;
        return false;
    }
    public void GameEnd()
    {
        ReloadAndWin.instance.Win();
        Debug.Log("GameOver");
    }
}
