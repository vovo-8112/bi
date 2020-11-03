using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI best;

    public int currentScore = 0;
    void Start()
    {
        GetBestScore();
    }
    void GetBestScore()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(int score)
    {

        currentScore += score;
        currentScoreText.text = currentScore.ToString();


        if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            bestScoreText.text = currentScore.ToString();
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
    }
}
