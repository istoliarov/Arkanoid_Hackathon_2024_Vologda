using Arkanoid.Scripts.Mono;
using UnityEngine;

namespace Arkanoid.Scripts {
    public class BallCreator : IObjectCreator<Ball> {
        private Ball prefab;

        public BallCreator(Ball prefab) {
            this.prefab = prefab;
        }

        public Ball Create(Transform parent, Vector3 position) {
            var newBall = Object.Instantiate(prefab, position, Quaternion.identity);
            newBall.transform.SetParent(parent, true);
            return newBall;
        }
    }
}