using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore;

    private int currentTurn;

    public int playTime;
    private int seconds;
    private int minutes;

    public Image YouWonPanel;

    [Header("Text connections")]
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TurnText;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
        StartCoroutine("PlayTime");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int scoreAmount)
    {
        currentTurn++;
        currentScore += scoreAmount;
        UpdateScoreText();
    }

    public void UpdateCurrentTurn()
    {
        currentTurn++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        ScoreText.text = "Score: " + currentScore.ToString("N");
        TurnText.text = "Turn: " + currentTurn;
    }

    IEnumerator PlayTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playTime++;
            seconds = (playTime % 60);
            minutes = (playTime / 60) % 60;
            UpdateTime();
        }
    }

    void UpdateTime()
    {
        TimeText.text = "Time: " + minutes.ToString("D2")+":"+seconds.ToString("D2");
    }

    public void StopTime()
    {
        StopCoroutine("PlayTime");
    }

    public void ToggleYouWon(bool value)
    {
        YouWonPanel.gameObject.SetActive(value);
    }
}
