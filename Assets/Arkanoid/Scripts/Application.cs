using Arkanoid.Scripts.Mono;
using UnityEngine;

namespace Arkanoid.Scripts
{
    public class Application : MonoBehaviour {
        [SerializeField] 
        private UIManager uiManager;

        [SerializeField] 
        private PrefabsProvider prefabsProvider;

        [SerializeField] 
        private SimpleTileGridGenerator simpleTileGridGenerator;

        [SerializeField]
        private Transform levelParent;

        [SerializeField] 
        private Transform platformSpawnPosition;

        [SerializeField]
        private ObjectHandler bottomHandler;

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

            uiManager.Initialize();
            gameManager.Initialize(
                levelParent,
                uiManager,
                bottomHandler,
                simpleTileGridGenerator,
                platformSpawnPosition.position, 
                inputHandler, 
                ballCreator, 
                movablePlatformCreator
            );
        }

        private void Update() {
            inputHandler.Update();
        }
    }
}