using TMPro;
using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class InfoBarScreen : Screen {
        [SerializeField]
        private TextMeshProUGUI hp;

        [SerializeField]
        private TextMeshProUGUI score;

        public void SetHp(int value) {
            hp.text = "HP: " + value;
        }

        public void SetScore(int value) {
            score.text = "SCORE: " + value;
        }
    }
}