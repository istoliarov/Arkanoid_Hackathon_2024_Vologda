using UnityEngine;

namespace Arkanoid.Scripts.Mono {
    public class SimpleTileGridGeneratorReport {
        public int GeneratedTiles;
    }

    public class SimpleTileGridGenerator : MonoBehaviour, ITilesLevelGenerator<SimpleTileGridGeneratorReport> {
        [SerializeField]
        private Transform parent;

        [SerializeField] 
        private GameObject[] tilePrefabs;

        [SerializeField] 
        private int minWidthPerTile;

        [SerializeField] 
        private int maxWidthPerTile;

        [SerializeField] 
        private int minHeightPerTile;

        [SerializeField] 
        private int maxHeightPerTile;

        public SimpleTileGridGeneratorReport Generate() {
            var widthPerTile = Random.Range(minWidthPerTile, maxWidthPerTile);
            var heightPerTile = Random.Range(minHeightPerTile, maxHeightPerTile);
            var halfWidthPerTileType = widthPerTile / 2;
            var gapBetweenTile = 0.5f;
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

            return new SimpleTileGridGeneratorReport() {
                GeneratedTiles = tilePrefabs.Length * heightPerTile * widthPerTile,
            };
        }
    }
}