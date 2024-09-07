using System;

namespace Arkanoid.Scripts {
    public class Health {
        private int value;
        private Action onNotAlive;

        public int Value => value;
        
        public bool IsAlive => value > 0;

        public Health(int value, Action onNotAlive) {
            this.value = value;
            this.onNotAlive = onNotAlive;
        }

        public void DealDamage(int damage) {
            value -= damage;
            if (!IsAlive) {
                onNotAlive?.Invoke();
            }
        }
    }
}