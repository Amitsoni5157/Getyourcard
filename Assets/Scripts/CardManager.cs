using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{
   //public GameSaveData gameSaveData;

    public List<Sprite> SpriteList = new List<Sprite>();

    [SerializeField] private List<GameObject> buttonList = new List<GameObject>();
    [SerializeField] private List<GameObject> hiddenButtonList = new List<GameObject>();

    private List<GameObject> choosenCard = new List<GameObject>();

    private int lastMatchId;

    [SerializeField] private bool is_Choosen;

    [Header("How Many pairs you want to play ?")]
    public int Pairs;

    [Header("Card Prefab Button")]
    public GameObject CardPrefab;

    [Header("The Parent Spacer to sort Cards in")]
   
    public Transform spacer2x2;
    public Transform spacer2x3;
    public Transform spacer5x6;


    [Header("Basic score per Match")]
    public int matchScore = 10;

    GridLayout _grd;

    public int Choice1;
    public int Choice2;

    [Header("Effect")]
    public GameObject fxExplosion;


   
    // Start is called before the first frame update
    void Start()
    {
        //gameSaveData = PlayerPrefsExtra.GetObject<GameSaveData>("GameSaveData",gameSaveData);

        Pairs = int.Parse(Constant.CheckPairOfGame);
        
        Debug.Log(Pairs+"::pairs");
        FlipPlayFields();
    }

    void FlipPlayFields()
    {
        switch (Constant._pairEnum)
        {
            case PairEnum.Two:
                for (int i = 0; i < (Pairs * 2); i++)
                {
                    GameObject newCard = Instantiate(CardPrefab, spacer2x2);
                    buttonList.Add(newCard);
                    hiddenButtonList.Add(newCard);
                }
                break;
            case PairEnum.Three:
                for (int i = 0; i < (Pairs * 2); i++)
                {
                    GameObject newCard = Instantiate(CardPrefab, spacer2x3);
                    buttonList.Add(newCard);
                    hiddenButtonList.Add(newCard);
                }
                break;
            case PairEnum.Five:
                for (int i = 0; i < (Pairs * 2); i++)
                {
                    GameObject newCard = Instantiate(CardPrefab, spacer5x6);
                    buttonList.Add(newCard);
                    hiddenButtonList.Add(newCard);
                }
                break;
            default:
                for (int i = 0; i < (Pairs * 2); i++)
                {
                    GameObject newCard = Instantiate(CardPrefab, spacer2x2);
                    buttonList.Add(newCard);
                    hiddenButtonList.Add(newCard);
                }
                break;
        }
       
        shuffleCard();
    }

    void shuffleCard()
    {
        int num = 0;
        int cardPairs = buttonList.Count / 2;

        for (int i = 0; i < cardPairs; i++)
        {
            num++;
            for (int j = 0; j < 2; j++)
            {
                int cardIndex = Random.Range(0, buttonList.Count);
                Card tempCard = buttonList[cardIndex].GetComponent<Card>();
                tempCard.id = num;
                tempCard.cardFront = SpriteList[num - 1];

                buttonList.Remove(buttonList[cardIndex]);
            }
        }
    }

    public void AddChoosenCard(GameObject card)
    {
        choosenCard.Add(card);
    }

    public IEnumerator CompareCards()
    {
        if (Choice2 == 0 || is_Choosen)
        {
            yield break;
        }
        is_Choosen = true;
        yield return new WaitForSeconds(1f);
    
        if((Choice1 != 0 && Choice2 != 0) && (Choice1 != Choice2))
        {
            Debug.Log("Flip back the open cards");
            FlipAllBack();

            //Reset the combo in Score Manger
            ScoreManager.Instance.UpdateCurrentTurn();
        }
        else if((Choice1 != 0 && Choice2 != 0) && (Choice1 == Choice2))
        {
            Debug.Log("Matched");
            SoundManager.Instance.PlayCardMatchMusic();
            lastMatchId = Choice1;
            //Add score
            ScoreManager.Instance.AddScore(matchScore);
            //Remove the Match
            RemoveMatch();
            //Clear ChoosenCards
            choosenCard.Clear();
        }
        //Reset All Choises
        Choice1 = 0;
        Choice2 = 0;
        is_Choosen = false;

        //Check if Won
        StartCoroutine("CheckWin");
    }

    void FlipAllBack()
    {
        foreach (GameObject card in choosenCard)
        {
            card.GetComponent<Card>().CloseCard();
        }
        choosenCard.Clear();
    }

    void RemoveMatch()
    {
        for (int i = hiddenButtonList.Count - 1 ; i  >= 0; i--)
        {
            Card tempCard = hiddenButtonList[i].GetComponent<Card>();
            if(tempCard.id == lastMatchId)
            {

                //Practicle FX
                Instantiate(fxExplosion,hiddenButtonList[i].transform.position,Quaternion.identity);

                //Remove the Match card
                hiddenButtonList[i].GetComponent<UnityEngine.UI.Image>().enabled = false;

                //Remove The Card
                hiddenButtonList.RemoveAt(i);
            }
        }
    }

    IEnumerator CheckWin()
    {
        yield return new WaitForSeconds(2f);
        if (hiddenButtonList.Count < 1)
        {
            //Stop Timer
            ScoreManager.Instance.StopTime();

            //Show UI

            //Play FireWorks

            //Show Stars
            ScoreManager.Instance.ToggleYouWon(true);
            Debug.Log("You Won");
            StopCoroutine("CheckWin");
        }

    }

/*    public void SaveGameData()
    {
        gameSaveData.Score_temp = ScoreManager.Instance.currentScore;
        gameSaveData.Time_temp = ScoreManager.Instance.playTime;
        gameSaveData.Turn_temp = ScoreManager.Instance.CurrentTurn;
        gameSaveData.hiddenButtonList_temp = hiddenButtonList;
        gameSaveData.spacer_temp = spacer2x3;

        PlayerPrefsExtra.SetObject("GameSaveData",gameSaveData);
    }

    public void SaveGame()
    {
        SaveGameData();
    }*/

}






