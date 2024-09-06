using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class Hittable : MonoBehaviour {
        public void Hit() {
            Destroy(gameObject);
        }
    }
}