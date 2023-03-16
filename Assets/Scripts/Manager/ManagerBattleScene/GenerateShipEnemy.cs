using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BattleShip
{
    public class GenerateShipEnemy : MonoBehaviour
    {
        public static GenerateShipEnemy _instance;
        public MatrixGenerate enemyMatrix;
        [SerializeField] private List<Ship> enemyShip;

        private Transform _containerEnemyShip;

        private void Awake()
        {
            _containerEnemyShip = GameObject.FindGameObjectWithTag("ContainerEnemyShip").transform;
        }

        private void Start()
        {
            if (_instance == null) {
                _instance = this;
            }
            else {
                Destroy(this);
            }
            enemyMatrix = new MatrixGenerate(10, 10, false);
            StartCoroutine(UpdateShip());
        }


        private IEnumerator UpdateShip()
        {
            int k = 0;
            while (k < 4) {
                int w = Random.Range(0, 9);
                int h = Random.Range(0, 9);
                if (PositionInTileSingle(w, h)) {
                    k++;
                }
            }

            yield return null;
            int i = 0;
            while (i < 3) {
                int x = Random.Range(0, 9);
                int y = Random.Range(0, 9);
                var isRotate = Random.Range(0, 2);
                if (PositionInTileDouble(x, y, isRotate)) {
                    i++;
                }
            }

            yield return null;
            int j = 0;
            while (j < 2) {
                int x = Random.Range(0, 9);
                int y = Random.Range(0, 9);
                var isRotate = Random.Range(0, 2);
                if (PositionInTileTriple(x, y, isRotate)) {
                    j++;
                }
            }

            yield return null;
        }

        private bool PositionInTileSingle(int x, int y)
        {
            if (enemyMatrix._matrixEnemy[x, y].objectInTile == ObjectInTile.Water) {
                enemyMatrix._matrixEnemy[x, y].objectInTile = ObjectInTile.Ship;
                var instantiate = Instantiate(enemyShip[0], enemyMatrix._matrixEnemy[x, y].transform.position, Quaternion.identity);
                enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                enemyMatrix._matrixEnemy[x, y].ship.shipType = TypeShip.EnemyShip;
                instantiate.GetComponentInChildren<MeshRenderer>().enabled = false;
                instantiate.tag = "EnemyShip";
                instantiate.transform.SetParent(_containerEnemyShip);
                return true;
            }

            return false;
        }

        private bool PositionInTileDouble(int x, int y, int isRotate)
        {

            var count = 0;
            if (isRotate == 0) {
                for (int i = 0; i < 1; i++) {
                    if (x + i < 9) {
                        count++;
                    }
                }

                if (count == 1) {
                    if (enemyMatrix._matrixEnemy[x, y].objectInTile == ObjectInTile.Water && enemyMatrix._matrixEnemy[x + 1, y].objectInTile == ObjectInTile.Water) {
                        enemyMatrix._matrixEnemy[x, y].objectInTile = ObjectInTile.PartOfShip;
                        enemyMatrix._matrixEnemy[x + 1, y].objectInTile = ObjectInTile.PartOfShip;
                        var instantiate = Instantiate(enemyShip[1], enemyMatrix._matrixEnemy[x, y].transform.position, Quaternion.identity);
                        instantiate.GetComponentInChildren<MeshRenderer>().enabled = false;
                        enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x + 1, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x, y].ship.shipType = TypeShip.EnemyShip;
                        enemyMatrix._matrixEnemy[x + 1, y].ship.shipType = TypeShip.EnemyShip;
                        instantiate.transform.Rotate(0, 90, 0);
                        instantiate.tag = "EnemyShip";
                        instantiate.transform.SetParent(_containerEnemyShip);
                        return true;
                    }
                }
                else {
                    return false;
                }
            }

            else if (isRotate == 1) {
                for (int i = 0; i < 1; i++) {
                    if (y + i < 9) {
                        count++;
                    }
                }

                if (count == 1) {
                    if (enemyMatrix._matrixEnemy[x, y].objectInTile == ObjectInTile.Water && enemyMatrix._matrixEnemy[x, y + 1].objectInTile == ObjectInTile.Water) {
                        enemyMatrix._matrixEnemy[x, y].objectInTile = ObjectInTile.PartOfShip;
                        enemyMatrix._matrixEnemy[x, y + 1].objectInTile = ObjectInTile.PartOfShip;
                        var instantiate = Instantiate(enemyShip[1], enemyMatrix._matrixEnemy[x, y].transform.position, Quaternion.identity);
                        instantiate.GetComponentInChildren<MeshRenderer>().enabled = false;
                        enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x, y + 1].ship = instantiate;
                        enemyMatrix._matrixEnemy[x, y].ship.shipType = TypeShip.EnemyShip;
                        enemyMatrix._matrixEnemy[x, y + 1].ship.shipType = TypeShip.EnemyShip;
                        instantiate.tag = "EnemyShip";
                        instantiate.transform.SetParent(_containerEnemyShip);
                        return true;
                    }
                }
                else {
                    return false;
                }
            }

            return default;
        }

        private bool PositionInTileTriple(int x, int y, int isRotate)
        {

            var count = 0;
            if (isRotate == 0) {
                for (int i = 0; i < 2; i++) {
                    if (x + i < 9) {
                        count++;
                    }
                }

                if (count == 2) {
                    if (enemyMatrix._matrixEnemy[x, y].objectInTile == ObjectInTile.Water && enemyMatrix._matrixEnemy[x + 1, y].objectInTile == ObjectInTile.Water && enemyMatrix._matrixEnemy[x + 2, y].objectInTile == ObjectInTile.Water) {
                        enemyMatrix._matrixEnemy[x, y].objectInTile = ObjectInTile.PartOfShip;
                        enemyMatrix._matrixEnemy[x + 1, y].objectInTile = ObjectInTile.PartOfShip;
                        enemyMatrix._matrixEnemy[x + 2, y].objectInTile = ObjectInTile.PartOfShip;
                        var instantiate = Instantiate(enemyShip[2], enemyMatrix._matrixEnemy[x, y].transform.position, Quaternion.identity);
                        instantiate.GetComponentInChildren<MeshRenderer>().enabled = false;
                        enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x + 1, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x + 2, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x, y].ship.shipType = TypeShip.EnemyShip;
                        enemyMatrix._matrixEnemy[x + 1, y].ship.shipType = TypeShip.EnemyShip;
                        enemyMatrix._matrixEnemy[x + 2, y].ship.shipType = TypeShip.EnemyShip;
                        instantiate.transform.Rotate(0, 90, 0);
                        instantiate.tag = "EnemyShip";
                        instantiate.transform.SetParent(_containerEnemyShip);
                        return true;
                    }
                }
                else {
                    return false;
                }
            }

            else if (isRotate == 1) {
                for (int i = 0; i < 2; i++) {
                    if (y + i < 9) {
                        count++;
                    }
                }

                if (count == 2) {
                    if (enemyMatrix._matrixEnemy[x, y].objectInTile == ObjectInTile.Water && enemyMatrix._matrixEnemy[x, y + 1].objectInTile == ObjectInTile.Water && enemyMatrix._matrixEnemy[x, y + 2].objectInTile == ObjectInTile.Water) {
                        enemyMatrix._matrixEnemy[x, y].objectInTile = ObjectInTile.PartOfShip;
                        enemyMatrix._matrixEnemy[x, y + 1].objectInTile = ObjectInTile.PartOfShip;
                        enemyMatrix._matrixEnemy[x, y + 2].objectInTile = ObjectInTile.PartOfShip;
                        var instantiate = Instantiate(enemyShip[2], enemyMatrix._matrixEnemy[x, y].transform.position, Quaternion.identity);
                        instantiate.GetComponentInChildren<MeshRenderer>().enabled = false;
                        enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x, y + 1].ship = instantiate;
                        enemyMatrix._matrixEnemy[x, y + 2].ship = instantiate;
                        enemyMatrix._matrixEnemy[x, y].ship.shipType = TypeShip.EnemyShip;
                        enemyMatrix._matrixEnemy[x, y + 1].ship.shipType = TypeShip.EnemyShip;
                        enemyMatrix._matrixEnemy[x, y + 2].ship.shipType = TypeShip.EnemyShip;
                        instantiate.tag = "EnemyShip";
                        instantiate.transform.SetParent(_containerEnemyShip);
                        return true;
                    }
                }
                else {
                    return false;
                }
            }

            return default;
        }

    }
}
