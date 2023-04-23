using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapCreate : MonoBehaviour
{
    [SerializeField] GridMapStageScriptObject _gridLayOut;
    [SerializeField] GameObject _tilePerfabs;
    public List<GameObject> _tilemap=new List<GameObject>();
    //public Vector2 cubeSize = new Vector2(1, 1);

    void Awake()
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        GetDataFromLayOut(_gridLayOut);
    }
    void GetDataFromLayOut(GridMapStageScriptObject layout)
    {
        for(int i=0; i < layout.GetGridLayOutLength(); i++)
        {
            Vector2 _gridPosition = layout.GetGridLayOutPosition(i);
            
            _tilemap.Add(CreateGridMap(_gridPosition));
        }
    }

    private GameObject CreateGridMap(Vector2 gridPosition)
    {
        return Instantiate(_tilePerfabs, gridPosition, Quaternion.identity);
    }

    //private void OnDrawGizmos()
    //{
    //    for (int x = 0; x < _tilemap.GetLength(0); x++)
    //    {
    //        for (int y = 0; y < _tilemap.GetLength(1); y++)
    //        {
    //            Gizmos.DrawWireCube(new Vector2(x,y), cubeSize);
    //        }
    //    }
    //}
}
