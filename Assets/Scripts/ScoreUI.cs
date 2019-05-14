using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public FloatReference playerScore;

    // Update is called once per frame
    private void Update()
    {
        UpdateTextScore();
    }
    
    private void UpdateTextScore()
    {
        scoreText.text = $"{playerScore.Value : 0}";
    }
}
