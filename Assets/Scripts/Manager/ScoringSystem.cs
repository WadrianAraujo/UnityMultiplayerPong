using TMPro;
using UnityEngine;

namespace Manager
{
    public class ScoringSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameController gameController;
        private int _scorePlayer1;
        private int _scorePlayer2;
        
        public void IncreaseScore(string player)
        {
            if (player == "player1")
            {
                _scorePlayer1++;
            }
            if (player == "player2")
            {
                _scorePlayer2++;
            }
            scoreText.text = _scorePlayer1 + " : " + _scorePlayer2;
            gameController.ResetGame();
        }
    }
}
