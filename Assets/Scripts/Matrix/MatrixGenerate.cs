using System;
using UnityEngine;

namespace BattleShip
{
    public class MatrixGenerate : MonoBehaviour
    {
        public Tile[,] _matrixPlayer;
        public Tile[,] _matrixEnemy;

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
            tile.transform.position = new Vector3(x * 1.5f - 15f, tile.transform.position.y + 0.01f, y * 1.5f - 15f);
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
            tile.transform.position = new Vector3(x * 1.5f + 18.5f, tile.transform.position.y + 0.01f, y * 1.5f - 15f);
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
    }
}

