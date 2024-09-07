using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Scripts.Mono {
    public class ReloadScene : MonoBehaviour {
        public void ReloadThisScene() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}