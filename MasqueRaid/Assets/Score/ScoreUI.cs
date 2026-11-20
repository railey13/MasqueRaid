using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text scoreText;

    public GameObject GameOver;
    public Text GameOverText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    public void updateScore(ScoreController scoreController)
    {
        scoreText.text = $"Score: {scoreController.Score}";


        if (scoreController.Score >= 100) {
            GameOver.SetActive(true);
            GameOverText.text = "Level Complete";
            Time.timeScale = 0f;
        }
    }

}
