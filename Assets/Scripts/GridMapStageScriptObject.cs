using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptObject/TileMap/Stage1")]
public class GridMapStageScriptObject : ScriptableObject
{
    [Serializable]
    public struct GridLayOut
    {
        public Vector2 _position;
    }
    [SerializeField] GridLayOut[] layout;

    public int GetGridLayOutLength()
    {
        return layout.Length;
    }
    public Vector2 GetGridLayOutPosition(int index)
    {
        return new Vector2(layout[index]._position.x,layout[index]._position.y);
    }
}
