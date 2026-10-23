using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Enemy_Scoring : MonoBehaviour
{
    [SerializeField]    private int enemyScore;

    private ScoreController _scoreController;

    private void Awake()
    {
        _scoreController = FindFirstObjectByType<ScoreController>();
    }

    public void allocateScore()
    {
        _scoreController.addScore(enemyScore);
    }

}
