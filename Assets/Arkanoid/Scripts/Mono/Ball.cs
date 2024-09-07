using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Scripts.Mono {
    public class Ball : MonoBehaviour {
        [SerializeField] 
        private Rigidbody2D body;

        [SerializeField] 
        private Vector2 startVelocity;

        private bool isActivated;

        private Action onHit;

        public Action OnHit {
            get => onHit;
            set => onHit = value;
        }

        public void Activate() {
            var direction = Random.Range(0.0f, 1.0f) > 0.5f ? -1 : 1;
            body.velocity = new Vector2(direction * startVelocity.x, startVelocity.y);
            isActivated = true;
        }

        public void Deactivate() {
            body.velocity = Vector3.zero;
            isActivated = false;
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            Bounce(collision.contacts[0].normal);

            var hittable = collision.gameObject.GetComponent<Hittable>();
            if (hittable != null && !hittable.Hitted) {
                hittable.Hit();
                onHit?.Invoke();
            }
        }

        private void Bounce(Vector2 collision2DNormal) {
            var direction = Vector3.Reflect(body.velocity.normalized, collision2DNormal);
            body.velocity = direction * startVelocity;
        }
    }
}