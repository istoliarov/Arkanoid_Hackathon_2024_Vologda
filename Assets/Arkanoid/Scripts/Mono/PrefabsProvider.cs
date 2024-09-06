using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    [CreateAssetMenu(fileName = "PrefabsProvider", menuName = "ScriptableObjects/PrefabsProvider", order = 1)]
    public class PrefabsProvider : ScriptableObject {
        [SerializeField] 
        private MovablePlatform movablePlatformPrefab;

        [SerializeField] 
        private Ball ballPrefab;

        public MovablePlatform GetMovablePlatform() {
            return movablePlatformPrefab;
        }

        public Ball GetBall() {
            return ballPrefab;
        } 
    }
}