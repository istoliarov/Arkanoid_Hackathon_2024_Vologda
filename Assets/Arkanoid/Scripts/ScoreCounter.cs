using System;

namespace Arkanoid.Scripts {
    public class ScoreCounter {
        private int scoreValue;
        private int targetScoreValue;

        private Action onTargetScoreReached;

        public int ScoreValue => scoreValue;

        public ScoreCounter(int targetScoreValue, Action onTargetScoreReached) {
            this.targetScoreValue = targetScoreValue;
            this.onTargetScoreReached = onTargetScoreReached;
        }

        public void AddScore(int value) {
            scoreValue += value;
            if (IsTargetScore()) {
                onTargetScoreReached?.Invoke();
            }
        }

        private bool IsTargetScore() {
            return scoreValue >= targetScoreValue;
        }
    }
}