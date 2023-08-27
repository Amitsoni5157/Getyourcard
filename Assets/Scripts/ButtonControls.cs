using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControls : MonoBehaviour
{
  
    public void RestartGame()
    {
        SceneManager.LoadScene("MenuScene");
        ScoreManager.Instance.ToggleYouWon(false);
    }

    public void TwoPair(int pair)
    {
        Constant.CheckPairOfGame = pair.ToString();
        Constant._pairEnum = PairEnum.Two;
        SceneManager.LoadScene("GamePlay");
    }

    public void TwoXThreePair(int pair)
    {
        Constant.CheckPairOfGame = pair.ToString();
        Constant._pairEnum = PairEnum.Three;
        SceneManager.LoadScene("GamePlay");

    }


    public void FiveXSixPair(int pair)
    {
        Constant.CheckPairOfGame = pair.ToString();
        Constant._pairEnum = PairEnum.Five;
        SceneManager.LoadScene("GamePlay");
    }
}


