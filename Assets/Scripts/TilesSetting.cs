using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSetting : MonoBehaviour
{
    public bool isFill;

    private void Awake()
    {
        SetData();
    }

    public void SetData()
    {
        isFill = false;
    }
}
