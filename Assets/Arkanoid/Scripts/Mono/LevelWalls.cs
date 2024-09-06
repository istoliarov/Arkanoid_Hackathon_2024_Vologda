using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class LevelWalls : MonoBehaviour {
        [SerializeField]
        private float wallThickness = 1f;

        [SerializeField]
        private SpriteRenderer topWall;
        
        [SerializeField]
        private SpriteRenderer bottomWall;
        
        [SerializeField]
        private SpriteRenderer leftWall;
        
        [SerializeField]
        private SpriteRenderer rightWall;

        private Vector2 fieldSize;
        private Camera camera;

        private void Awake () {
            camera = Camera.main;
            MakeWalls();
        }

        private void MakeWalls()
        {
            FillFieldSize();
            SetConstraints();
        }

        private void FillFieldSize() {
            fieldSize.y = 2f * camera.orthographicSize;
            fieldSize.x = fieldSize.y * camera.aspect;
        }

        private void SetConstraints() {
            if (!bottomWall || !topWall || !leftWall || !rightWall) {
                return;
            }

            bottomWall.gameObject.transform.position = new Vector3(0, -fieldSize.y * 0.5f + wallThickness * 0.5f, 0);
            topWall.gameObject.transform.position = new Vector3(0, fieldSize.y * 0.5f - wallThickness * 0.5f, 0);
            topWall.size = bottomWall.size = new Vector2(fieldSize.x + 2, wallThickness);

            leftWall.gameObject.transform.position = new Vector3(-fieldSize.x * 0.5f + wallThickness * 0.5f, 0, 0);
            rightWall.gameObject.transform.position = new Vector3(fieldSize.x * 0.5f - wallThickness * 0.5f, 0, 0);
            leftWall.size = rightWall.size = new Vector2(wallThickness, fieldSize.y + 2);
        }
    }
}