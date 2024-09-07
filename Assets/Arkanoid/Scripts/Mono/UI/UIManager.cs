using System;
using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class UIManager : MonoBehaviour {
        [SerializeField] 
        private HowToScreen howToScreen;

        [SerializeField] 
        private InfoBarScreen infoBarScreen;

        [SerializeField] 
        private Screen gameOverScreen;

        [SerializeField] 
        private Screen winScreen;

        public HowToScreen HowToScreen => howToScreen;

        public InfoBarScreen InfoBarScreen => infoBarScreen;

        public Screen GameOverScreen => gameOverScreen;

        public Screen WinScreen => winScreen;

        public void Initialize() {
            howToScreen.Hide();
            infoBarScreen.Hide();
            gameOverScreen.Hide();
            winScreen.Hide();
        }
    }
}