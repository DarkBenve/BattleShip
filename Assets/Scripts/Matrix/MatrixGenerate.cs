using System;
using UnityEngine;

namespace BattleShip
{
    public class MatrixGenerate : MonoBehaviour
    {
        public Tile[,] _matrixPlayer;
        public Tile[,] _matrixEnemy;

        private MainMenu _mainMenu;


        private void Start()
        {
            _mainMenu = FindObjectOfType<MainMenu>();
            _mainMenu._onReset += DestroyMatrix;
        }

        public MatrixGenerate(int width, int height, bool isMatrixPlayer)
        {
            _matrixPlayer = new Tile[width, height];
            _matrixEnemy = new Tile[width, height];

            if (isMatrixPlayer)
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        _matrixPlayer[x,y] = GenerateTileObjectPlayer(x, y);
                        SetParentTile("ContainerMatrix", _matrixPlayer[x, y]);
                    }
                }
            else
                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        _matrixEnemy[x,y] = GenerateTileObjectEnemy(x, y);
                        SetParentTile("ContainerMatrixEnemy", _matrixEnemy[x, y]);
                    }
                }
        }

        private void SetParentTile(string nameObject, Tile tile)
        {
            var container = GameObject.Find(nameObject);
            Debug.Log(container);
            tile.transform.parent = container.transform;
        }

        private Tile GenerateTileObjectPlayer(int x, int y)
        {
            GameObject tile = new GameObject(x + "," + y);
            tile.transform.position = new Vector3(x * 2f - 17, tile.transform.position.y + 0.01f, y * 2f - 17.5f);
            tile.transform.localScale = new Vector3(1.5f, 1, 1.5f);
            tile.transform.Rotate(new Vector3(0, 0));
            Mesh mesh = Resources.Load<Mesh>("Hex19");
            Material meshMaterial = Resources.Load<Material>("HexagonsShared");
            MeshFilter meshFilter = tile.AddComponent<MeshFilter>();
            meshFilter.mesh = mesh;
            MeshRenderer meshRender = tile.AddComponent<MeshRenderer>();
            meshRender.material = meshMaterial;
            MeshCollider boxTile = tile.AddComponent<MeshCollider>();
            boxTile.sharedMesh = mesh;
            tile.AddComponent<Tile>();

            return tile.GetComponent<Tile>();
        }

        private Tile GenerateTileObjectEnemy(int x, int y)
        {
            GameObject tile = new GameObject(x + "," + y);
            tile.transform.position = new Vector3(x * 2 + 17f, tile.transform.position.y + 0.01f, y * 2 - 17.5f);
            tile.transform.localScale = new Vector3(1.5f, 1, 1.5f);
            tile.transform.Rotate(new Vector3(0, 0));
            Mesh mesh = Resources.Load<Mesh>("Hex19");
            Material meshMaterial = Resources.Load<Material>("HexagonsShared");
            MeshFilter meshFilter = tile.AddComponent<MeshFilter>();
            meshFilter.mesh = mesh;
            MeshRenderer meshRender = tile.AddComponent<MeshRenderer>();
            meshRender.material = meshMaterial;
            MeshCollider boxTile = tile.AddComponent<MeshCollider>();
            boxTile.sharedMesh = mesh;
            tile.AddComponent<TileEnemy>();

            return tile.GetComponent<Tile>();
        }


        private void DestroyMatrix()
        {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    _matrixPlayer[i, j] = null;
                }
            }
        }

    }
}

