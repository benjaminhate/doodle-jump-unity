﻿using ScriptableObjects;
using UnityEngine;

namespace Game
{
    public class ScoreManager : MonoBehaviour
    {
        public Transform player;
        public FloatVariable playerScore;

        public const string ScorePrefs = "score";

        private float _playerMaxY;

        private float _baseY;

        private void Start()
        {
            _baseY = _playerMaxY;
        
            ResetScore();
        }

        private void Update()
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            var playerPos = player.position;
            if (!(playerPos.y > _playerMaxY)) return;
        
            _playerMaxY = playerPos.y;

            playerScore.value = _playerMaxY * 20;
        }

        public void ResetScore()
        {
            _playerMaxY = _baseY;
            playerScore.value = 0f;
        }

        public void SaveScore()
        {
            var highscore = GetSavedScore();
            if(playerScore.value > highscore)
                PlayerPrefs.SetFloat(ScorePrefs, playerScore.value);
        }

        private float GetSavedScore()
        {
            return PlayerPrefs.GetFloat(ScorePrefs);
        }
    }
}
