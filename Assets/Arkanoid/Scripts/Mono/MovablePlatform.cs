using UnityEngine;

namespace Arkanoid.Scripts.Mono
{
    public class MovablePlatform : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody2D body;

        [SerializeField] 
        private float moveVelocity;

        private Vector2 leftMoveVelocity;
        private Vector2 rightMoveVelocity;

        private Ball catchedBall;
        private Transform ballParentBeforeCatch;
        
        private SizeController sizeController;

        public enum MoveDirection {
            None,
            Left,
            Right,
        }

        public void Initialize() {
            leftMoveVelocity = new Vector2(-moveVelocity, 0);
            rightMoveVelocity = new Vector2(moveVelocity, 0);

            sizeController = new SizeController(1.0f, 0.25f, 0.025f, () => {
                transform.localScale = new Vector3(sizeController.CurrentSize, transform.localScale.y, transform.localScale.z);
            });
        }

        public void Move(MoveDirection direction) {
            body.velocity = direction switch {
                MoveDirection.Left => leftMoveVelocity,
                MoveDirection.Right => rightMoveVelocity,
                _ => Vector2.zero
            };
        }

        public void CatchBall(Ball ball) {
            if (catchedBall != null) {
                return;
            }
            catchedBall = ball;
            catchedBall.Deactivate();
            catchedBall.transform.position = transform.position + new Vector3(0, 1, 0);
            catchedBall.transform.SetParent(transform, true);
        }

        public void ThrowBall() {
            if (catchedBall == null) {
                return;
            }
            catchedBall.transform.SetParent(ballParentBeforeCatch, true);
            catchedBall.Activate();
            catchedBall = null;
        }

        private void OnCollisionEnter2D(Collision2D other) {
            var ball = other.gameObject.GetComponent<Ball>();
            if (ball != null) {
                sizeController.DecreaseSize();
            }
        }
    }
}