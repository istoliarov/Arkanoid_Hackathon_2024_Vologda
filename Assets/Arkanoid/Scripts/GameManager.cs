using Arkanoid.Scripts.Mono;
using UnityEngine;

namespace Arkanoid.Scripts {
    public class GameManager {
        private Ball ball;
        private MovablePlatform platform;

        public void Initialize(
            Transform level,
            ITilesLevelGenerator tilesLevelGenerator,
            Vector3 platformSpawnPosition,
            InputHandler inputHandler,
            IObjectCreator<Ball> ballCreator,
            IObjectCreator<MovablePlatform> platformCreator
        ) {
            tilesLevelGenerator.Generate();
            
            ball = ballCreator.Create(level, platformSpawnPosition);
            platform = platformCreator.Create(level, platformSpawnPosition);

            platform.CatchBall(ball);

            inputHandler.OnLeftAndRightReleased += () => platform.Move(MovablePlatform.MoveDirection.None);
            inputHandler.OnLeftButtonPressed += () => platform.Move(MovablePlatform.MoveDirection.Left);
            inputHandler.OnRightButtonPressed += () => platform.Move(MovablePlatform.MoveDirection.Right);
            inputHandler.OnThrowBallButtonPressed += GameStart;
        }

        private void GameStart() {
            platform.ThrowBall();
        }

        private void GameOver() {
            // TODO
        }
    }
}