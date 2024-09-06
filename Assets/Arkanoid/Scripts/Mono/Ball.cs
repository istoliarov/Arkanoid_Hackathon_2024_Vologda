using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class Ball : MonoBehaviour {
        [SerializeField] 
        private Rigidbody2D body;

        [SerializeField] 
        private Vector2 startVelocity;

        private bool isActivated;

        public void Activate() {
            var direction = Random.Range(0.0f, 1.0f) > 0.5f ? -1 : 1;
            body.velocity = new Vector2(direction * startVelocity.x, startVelocity.y);
            isActivated = true;
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            Bounce(collision.contacts[0].normal);

            var hittable = collision.gameObject.GetComponent<Hittable>();
            if (hittable != null) {
                hittable.Hit();
            }
        }

        private void Bounce(Vector2 collision2DNormal) {
            var velocity = body.velocity;
            var speed = body.velocity.magnitude;
            var direction = Vector3.Reflect(velocity.normalized, collision2DNormal);
            body.velocity = direction * Mathf.Max(speed, startVelocity.y);
        }
    }
}