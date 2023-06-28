using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptObject/Card/Shape")]
public class CardScirptObject : ScriptableObject
{
    //public int whereIsTrigger;
    [Serializable]
    public struct CardLayOut
    {
        public Vector2 _tilePosition;
    }
    [SerializeField] CardLayOut[] layout;

    public int GetCardLayOutLength()
    {
        return layout.Length;
    }
    public Vector2 GetCardLayOutPosition(int index)
    {
        return new Vector2(layout[index]._tilePosition.x, layout[index]._tilePosition.y);
    }
    //public int GetWhereIsTrigger()
    //{
        //return whereIsTrigger;
    //}

    [Serializable]
    public struct TriggerLayout
    {
        //public Vector2 _tileTriggerPosition;
    }
    //[SerializeField] TriggerLayout _triggerTileLayout;

    //public Vector2 GetTrigerLayoutPosition()
    //{
        //return new Vector2(_triggerTileLayout._tileTriggerPosition.x, _triggerTileLayout._tileTriggerPosition.y);
    //}
}