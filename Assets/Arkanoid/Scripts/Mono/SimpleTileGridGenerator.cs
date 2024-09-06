using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class SimpleTileGridGenerator : MonoBehaviour, ITilesLevelGenerator {
        [SerializeField]
        private Transform parent;

        [SerializeField] 
        private GameObject[] tilePrefabs;

        [SerializeField] 
        private int widthPerTile;
        
        [SerializeField] 
        private int heightPerTile;

        public void Generate() {
            int halfWidthPerTileType = widthPerTile / 2;
            const int tileSizeStep = 1;

            for (var i = 0; i < tilePrefabs.Length; i++) {
                var prefab = tilePrefabs[i];
                for (var column = 0; column < widthPerTile; column += tileSizeStep) {
                    for (var row = 0; row < heightPerTile; row += tileSizeStep) {
                        var position = new Vector3(column - halfWidthPerTileType, heightPerTile * i + row);
                        var newTile = Instantiate(prefab, parent);
                        newTile.transform.position = position;
                    }
                }
            }
        }
    }
}