using UnityEngine;

namespace Arkanoid.Scripts {
    public interface IObjectCreator<out T> {
        T Create(Transform parent, Vector3 position);
    }
}