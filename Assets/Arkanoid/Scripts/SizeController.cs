using System;

namespace Arkanoid.Scripts {
    public class SizeController {
        private float currentSize;

        private float defaultSize;
        private float minSize;
        private float decreaseStep;
        
        private Action onDecrease;

        public float CurrentSize => currentSize;

        public SizeController(float defaultSize, float minSize, float decreaseStep, Action onDecrease) {
            this.defaultSize = defaultSize;
            currentSize = this.defaultSize;
            this.minSize = minSize;
            this.decreaseStep = decreaseStep;
            this.onDecrease = onDecrease;
        }

        public void DecreaseSize() {
            if (currentSize <= minSize) {
                return;
            }
            currentSize -= decreaseStep;
            onDecrease?.Invoke();
            if (currentSize < minSize) {
                currentSize = minSize;
            }
        }
    }
}