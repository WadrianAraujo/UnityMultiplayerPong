using Manager;
using UnityEngine;

namespace Ball
{
    public class BallGoal : MonoBehaviour
    {
        [SerializeField]private ScoringSystem scoringSystem;
        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("saiu do gol");
            switch (other.gameObject.tag)
            {
                case "BoardLeft":
                    scoringSystem.IncreaseScore("player2");
                    break;
            
                case "BoardRight":
                    scoringSystem.IncreaseScore("player1");
                    break;    
            }
        }
    }
}
