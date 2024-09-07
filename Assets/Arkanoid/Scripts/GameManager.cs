using Arkanoid.Scripts.Mono;
using UnityEngine;

namespace Arkanoid.Scripts {
    public class GameManager {
        private Ball ball;
        private MovablePlatform platform;

        private UIManager uiManager;
        private InputHandler inputHandler;
        
        private Health health;
        private ScoreCounter scoreCounter;
        
        private bool isGameStarted;

        public void Initialize(
            Transform level,
            UIManager uiManager,
            ObjectHandler bottomHandler,
            ITilesLevelGenerator<SimpleTileGridGeneratorReport> tilesLevelGenerator,
            Vector3 platformSpawnPosition,
            InputHandler inputHandler,
            IObjectCreator<Ball> ballCreator,
            IObjectCreator<MovablePlatform> platformCreator
        ) {
            this.uiManager = uiManager;
            this.inputHandler = inputHandler;

            uiManager.HowToScreen.Show();

            var generatorReport = tilesLevelGenerator.Generate();

            ball = ballCreator.Create(level, platformSpawnPosition);
            platform = platformCreator.Create(level, platformSpawnPosition);

            platform.CatchBall(ball);

            health = new Health(3, GameOver);
            scoreCounter = new ScoreCounter(generatorReport.GeneratedTiles, GameWin);
            uiManager.InfoBarScreen.SetHp(health.Value);
            uiManager.InfoBarScreen.SetScore(scoreCounter.ScoreValue);

            inputHandler.OnLeftAndRightReleased += () => platform.Move(MovablePlatform.MoveDirection.None);
            inputHandler.OnLeftButtonPressed += () => platform.Move(MovablePlatform.MoveDirection.Left);
            inputHandler.OnRightButtonPressed += () => platform.Move(MovablePlatform.MoveDirection.Right);
            inputHandler.OnThrowBallButtonPressed += () => {
                platform.ThrowBall();

                GameStart();

                uiManager.HowToScreen.Hide();
                uiManager.InfoBarScreen.Show();
            };

            bottomHandler.OnHandle += () => {
                health.DealDamage(1);

                uiManager.InfoBarScreen.SetHp(health.Value);

                platform.transform.position = platformSpawnPosition;
                platform.CatchBall(ball);
            };

            ball.OnHit += () => {
                scoreCounter.AddScore(1);

                uiManager.InfoBarScreen.SetScore(scoreCounter.ScoreValue);
            };
        }

        private void GameStart() {
            if (isGameStarted) {
                return;
            }

            isGameStarted = true;
        }

        private void GameOver() {
            uiManager.GameOverScreen.Show();
            inputHandler.LockInput();
            platform.CatchBall(ball);
        }

        private void GameWin() {
            uiManager.WinScreen.Show();
            inputHandler.LockInput();
            platform.CatchBall(ball);
        }
    }
}