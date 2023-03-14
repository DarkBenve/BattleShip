using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BattleShip
{
    public class GenerateShipEnemy : MonoBehaviour
    {
        public MatrixGenerate enemyMatrix;
        [SerializeField] private List<Ship> enemyShip;

        private Transform _containerEnemyShip;

        private void Awake()
        {
            _containerEnemyShip = GameObject.FindGameObjectWithTag("ContainerEnemyShip").transform;
        }

        private void Start()
        {
            enemyMatrix = new MatrixGenerate(10, 10, false);
            StartCoroutine(UpdateShip());
        }


        private IEnumerator UpdateShip()
        {
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

        private void PositionInTileSingle(int x, int y)
        {
            if (enemyMatrix._matrixEnemy[x, y].objectInTile == ObjectInTile.Water)
                enemyMatrix._matrixEnemy[x, y].objectInTile = ObjectInTile.Ship;
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
                        enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x + 1, y].ship = instantiate;
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
                        enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x, y + 1].ship = instantiate;
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
                        enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x + 1, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x + 2, y].ship = instantiate;
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
                        enemyMatrix._matrixEnemy[x, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x + 1, y].ship = instantiate;
                        enemyMatrix._matrixEnemy[x + 2, y].ship = instantiate;
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
