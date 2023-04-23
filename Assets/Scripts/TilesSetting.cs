using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSetting : MonoBehaviour
{
    public bool _isFill;

    private void Awake()
    {
        SetData();
    }

    void SetData()
    {
        _isFill = false;
    }
}
