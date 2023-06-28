using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreate : MonoBehaviour
{
    [SerializeField] List<GameObject> Card;
    [SerializeField] GameObject GameManager;
    [SerializeField] List<CardScirptObject> _cardlayout;
    public List<GameObject> originPosition;

    void Awake()
    {
        for (int i = 0; i < Card.Count; i++)
        {
            GameObject gamecard = Instantiate(Card[i], originPosition[i].transform.position, Quaternion.identity);
            CardController setGameCard = gamecard.GetComponent<CardController>();
            setGameCard._originalPosition = originPosition[i];
            setGameCard._layout = _cardlayout[i];
            setGameCard._gridMapCreate = GameManager.GetComponent<GridMapCreate>();
            setGameCard._gridMapManager = GameManager.GetComponent<GridMapManager>();
            setGameCard._tileMapManger = GameManager.GetComponent<TIleMapManger>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
