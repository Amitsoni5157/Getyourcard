using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPairGame
{
    None,
    Two_X_Two,
    Two_X_Three,
    Five_X_Six,
}
public class GameCatagery : MonoBehaviour
{
    private int _PairCount;
    private EPairGame _eGamePair;

    public static GameCatagery Instance;

    private GameCatagery gameCatagery;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameCatagery = new GameCatagery();
        ResetAllSetting();
    }

   public void SetPairNumber(EPairGame num)
    {
        if (gameCatagery._eGamePair == EPairGame.None)
            _PairCount++;
        gameCatagery._eGamePair = num;
    }

    public EPairGame GetPairNumber()
    {
        return gameCatagery._eGamePair;
    }

    public void ResetAllSetting()
    {
        _PairCount = 0;
        gameCatagery._eGamePair = EPairGame.None;
    }
}
