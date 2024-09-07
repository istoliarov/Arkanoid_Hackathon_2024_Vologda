using System;
using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class ObjectHandler : MonoBehaviour {
        private Action onHandle;

        public Action OnHandle {
            get => onHandle;
            set => onHandle = value;
        }

        public void OnCollisionEnter2D(Collision2D other) {
            onHandle?.Invoke();
        }
    }
}