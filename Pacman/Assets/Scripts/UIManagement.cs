using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mScoreText;
    private int mScore = 0;

    [SerializeField] private TextMeshProUGUI mLivesText;
    [SerializeField] private int mLives = 3;
    private void OnEnable()
    {
        Coin.OnCoinCollect += ScoreIncrease;
        PlayerHealth.OnDeath += Death;
    }
    
    private void OnDisable()
    {
        Coin.OnCoinCollect -= ScoreIncrease;
        PlayerHealth.OnDeath -= Death;
    }

    private void ScoreIncrease()
    {
        // TODO find how to do events that pass values through, allow score to be incrimented by variable amounts
        mScore += 100;
        mScoreText.text = "Score : " + mScore.ToString(); // TODO remove
        
    }

    private void Death()
    {
        --mLives;
        mLivesText.text = "Lives : " + mLives.ToString();
    }
}
