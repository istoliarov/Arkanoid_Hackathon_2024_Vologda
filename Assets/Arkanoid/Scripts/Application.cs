using Arkanoid.Scripts.Mono;
using UnityEngine;

namespace Arkanoid.Scripts
{
    public class Application : MonoBehaviour {
        [SerializeField] 
        private PrefabsProvider prefabsProvider;

        [SerializeField]
        private Transform levelParent;

        [SerializeField] 
        private Transform platformSpawnPosition;

        private GameManager gameManager;
        private InputHandler inputHandler;

        private MovablePlatformCreator movablePlatformCreator;
        private BallCreator ballCreator;

        private void Awake() {
            Initialize();
        }

        private void Initialize() {
            UnityEngine.Application.targetFrameRate = 60;

            gameManager = new GameManager();
            inputHandler = new InputHandler();

            movablePlatformCreator = new MovablePlatformCreator(prefabsProvider.GetMovablePlatform());
            ballCreator = new BallCreator(prefabsProvider.GetBall());

            gameManager.Initialize(levelParent, platformSpawnPosition.position, inputHandler, ballCreator, movablePlatformCreator);
        }

        private void Update() {
            inputHandler.Update();
        }
    }
}