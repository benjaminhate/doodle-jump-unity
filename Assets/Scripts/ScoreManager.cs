using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    public Player player;
    public FloatVariable playerScore;
    
    private float _playerMaxY;

    private float _baseY;
    private float _baseScore;

    private void Start()
    {
        _baseY = _playerMaxY;
        _baseScore = playerScore.value;
        
        ResetScore();
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        var playerPos = player.transform.position;
        if (!(playerPos.y > _playerMaxY)) return;
        
        _playerMaxY = playerPos.y;

        playerScore.value = _playerMaxY * 20;
    }

    public void ResetScore()
    {
        _playerMaxY = _baseY;
        playerScore.value = _baseScore;
    }
}
