using System;
using UnityEngine;

namespace Ball
{
    public class BallBounce : MonoBehaviour
    {
        [SerializeField] private BallMovement _ballMovement;

        private void Bounce(Collision2D collision2D)
        {
            Vector3 ballPosition = transform.position;
            Vector3 racketPosition = collision2D.transform.position;
            float racketHeight = collision2D.collider.bounds.size.y;
            float positionX;

            if (collision2D.gameObject.CompareTag("Player1"))
            {
                positionX = 1;
            }
            else
            {
                positionX = -1;
            }

            float positionY = (ballPosition.y - racketPosition.y) / racketHeight;
        
            _ballMovement.IncreaseHitCounter();
            _ballMovement.MoveBall(new Vector2(positionX,positionY));
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2"))
            {
                Bounce(col);
            }
        }
    }
}
