using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShapeCreate : MonoBehaviour
{
    [SerializeField] GameObject _cardPerfabs;
    public List<GameObject> _cardMap = new List<GameObject>();

    public List<GameObject> GetCardDateAndCreate(CardScirptObject layout)
    {
        for (int i = 0; i < layout.GetCardLayOutLength(); i++)
        {
            Vector2 _cardTilePosition = layout.GetCardLayOutPosition(i);

            _cardMap.Add(CreateCardTile(_cardTilePosition));
        }
        return _cardMap;
    }
    //public GameObject GetTrigerDataAndCreate(CardScirptObject layoutOfTrigger)
    //{
        //return CreateCardTile(layoutOfTrigger.GetTrigerLayoutPosition());
    //}

    private GameObject CreateCardTile(Vector2 cardTilePosition)
    {
        return Instantiate(_cardPerfabs, cardTilePosition, Quaternion.identity);
    }

}
