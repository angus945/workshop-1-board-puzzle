using System;
using System.Collections;
using System.Collections.Generic;
using Array2DEditor;
using UnityEngine;

public class GridMapCreate : MonoBehaviour
{
    [SerializeField] GridMapStageScriptObject _gridLayOut;
    [SerializeField] GameObject _tilePerfabs;
    public List<GameObject> _tilemap=new List<GameObject>();
    public Array2DBool grid;

    void Awake()
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        //GetDataFromLayOut(_gridLayOut);
        CreateGridFromArray2D();
    }
    //void GetDataFromLayOut(GridMapStageScriptObject layout)
    //{
    //    for(int i=0; i < layout.GetGridLayOutLength(); i++)
    //    {
    //        Vector2 _gridPosition = layout.GetGridLayOutPosition(i);
    //        
    //        _tilemap.Add(CreateGridMap(_gridPosition));
    //    }
    //}

    //private GameObject CreateGridMap(Vector2 gridPosition)
    //{
    //    return Instantiate(_tilePerfabs, gridPosition, Quaternion.identity);
    //}
    private GameObject CreateGridMap(int x,int y)
    {
        return Instantiate(_tilePerfabs,new Vector2(x-7,-y+7), Quaternion.identity);
    }
    void CreateGridFromArray2D()
    {
        for (int x = 0; x < grid.GridSize.x; x++)
        {
            for (int y = 0; y < grid.GridSize.y; y++)
            {
                if (grid.GetCell(x,y))
                {
                    _tilemap.Add(CreateGridMap(x, y));
                }
            }
        }
    }
}
