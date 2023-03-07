using System;
using UnityEngine;

namespace BattleShip
{
    public class MatrixGenerate : MonoBehaviour
    {
        protected Tile[,] _matrixPlayer;
        protected Tile[,] _matrixEnemy;

        public MatrixGenerate(int width, int height, bool isMatrixPlayer)
        {
            _matrixPlayer = new Tile[width, height];
            _matrixEnemy = new Tile[width, height];

            if (isMatrixPlayer)
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        _matrixPlayer = new Tile[x, y];
                        GameObject tile = GenerateTileObjectPlayer(x, y);
                        SetParentTile("ContainerMatrix", tile);
                    }
                }
            else
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        _matrixEnemy = new Tile[x, y];
                        GameObject tile = GenerateTileObjectEnemy(x, y);
                        SetParentTile("ContainerMatrix", tile);
                    }
                }
        }

        private void SetParentTile(string nameObject, GameObject tile)
        {
            var container = GameObject.Find(nameObject);
            Debug.Log(container);
            tile.transform.parent = container.transform;
        }

        private GameObject GenerateTileObjectPlayer(int x, int y)
        {
            GameObject tile = new GameObject(x + "," + y);
            tile.transform.position = new Vector3(x - 9.5f, tile.transform.position.y + 0.01f, y - 9.5f);
            tile.transform.Rotate(new Vector3(90, 0));
            BoxCollider boxTile = tile.AddComponent<BoxCollider>();
            boxTile.size = new Vector3(1, 1, 0);
            Sprite sprite = Resources.Load<Sprite>("tileImage");
            var spriteRenderer = tile.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            tile.AddComponent<Tile>();

            return tile;
        }

        private GameObject GenerateTileObjectEnemy(int x, int y)
        {
            GameObject tile = new GameObject(x + "," + y);
            tile.transform.position = new Vector3(x + 10.5f, tile.transform.position.y + 0.01f, y - 9.5f);
            tile.transform.Rotate(new Vector3(90, 0));
            Sprite sprite = Resources.Load<Sprite>("tileImage");
            var spriteRenderer = tile.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;

            return tile;
        }
    }
}

