using System.Collections;
using UnityEngine;

namespace Ball
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private float startSpeedBall;
        [SerializeField] private float extraSpeedBall;
        [SerializeField] private float maxExtraSpeedBall;

        private int _hitCounter = 1;
        private Rigidbody2D _rigidbody2D;
        private Rigidbody2D _initialRigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            StartCoroutine(LaunchBall());
        }

        public IEnumerator LaunchBall()
        {
            _hitCounter = 0;
            _rigidbody2D.velocity = Vector2.zero;
            transform.position = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(1);
            MoveBall(new Vector2(-1, 0));
        }

        public void MoveBall(Vector2 direction)
        {
            direction = direction.normalized;
            float ballSpeed = startSpeedBall + _hitCounter * extraSpeedBall;
            _rigidbody2D.velocity = direction * ballSpeed;
        }

        public void IncreaseHitCounter()
        {
            if (_hitCounter * extraSpeedBall < maxExtraSpeedBall)
            {
                _hitCounter++;
            }
        }
    }
}
