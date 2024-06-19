using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //UI text를 불러오기 위한 부분


public class scoremanager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //점수를 표시할 UI 텍스트 
    public GameObject scorePrefab;  //득점시 점수 프리팹

    public Canvas mainCanvas; //Canvas를 Inspector에서 할당 
    
    private int score = 0;
   
    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        
    }

    public void minusScore(int amount)
    {
        score -= amount;
        UpdateScoreText();
    }

    private void UpdateScoreText() 
    {
        scoreText.text = "Score: " + score;
    }


}
