using UnityEngine;

namespace Arkanoid.Scripts.Mono
{
    public class UnityApplicationHelper : MonoBehaviour
    {
        public void Exit()
        {
            UnityEngine.Application.Quit();
        }
    }
}