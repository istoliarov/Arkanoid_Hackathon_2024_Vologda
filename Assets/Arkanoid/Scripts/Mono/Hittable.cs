using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class Hittable : MonoBehaviour {
        private bool hitted;

        public bool Hitted => hitted;

        public void Hit() {
            if (hitted) {
                return;
            }
            Destroy(gameObject);
            hitted = true;
        }
    }
}