using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CardData
{
    public int Id;
    public bool IsMatched;



}

[System.Serializable]
public class CardGameData
{
    public int turns;
    public int time;
    public int score;
    public List<CardData> _cardData = new List<CardData>();

} 