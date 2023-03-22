using Ball;
using Player;
using UnityEngine;

namespace Manager
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private BallMovement ballMovement;
        
        public void ResetGame()
        {
            playerController.ResetPosition();
            StartCoroutine(ballMovement.LaunchBall());
        }
    }
}
