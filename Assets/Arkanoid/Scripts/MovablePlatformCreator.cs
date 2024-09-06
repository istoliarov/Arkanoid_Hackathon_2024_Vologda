using Arkanoid.Scripts.Mono;
using UnityEngine;

namespace Arkanoid.Scripts {
    public class MovablePlatformCreator : IObjectCreator<MovablePlatform> {
        private MovablePlatform prefab;

        public MovablePlatformCreator(MovablePlatform prefab) {
            this.prefab = prefab;
        }

        public MovablePlatform Create(Transform parent, Vector3 position) {
            var newMovablePlatform = Object.Instantiate(prefab, position, Quaternion.identity);
            newMovablePlatform.transform.SetParent(parent, true);
            newMovablePlatform.Initialize();
            return newMovablePlatform;
        }
    }
}