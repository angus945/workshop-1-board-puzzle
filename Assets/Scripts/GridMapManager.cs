using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapManager : MonoBehaviour
{
    [SerializeField] GridMapCreate _gridMapCreate;

    public void ShowWhichIsNotFill()
    {
        for (int i = 0; i < _gridMapCreate._tilemap.Count; i++)
        {
            if (_gridMapCreate._tilemap[i].GetComponent<TilesSetting>()._isFill == false)
            {
                _gridMapCreate._tilemap[i].GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                _gridMapCreate._tilemap[i].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
