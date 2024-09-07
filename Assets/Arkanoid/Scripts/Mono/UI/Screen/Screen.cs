using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class Screen : MonoBehaviour {
        public virtual void Show() {
            gameObject.SetActive(true);
        }

        public virtual void Hide() {
            gameObject.SetActive(false);
        }
    }
}