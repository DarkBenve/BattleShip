﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleShip
{
    public static class ManagerBattleSystem
    {
        public static bool _isTurnEnemy;
        public static bool _isTurnPlayer;

        private static bool AttackEnemy(int x, int y)
        {
            if (!SaveMatrixBattle._instance._matrix[x, y].isSelectedThisTile) {
                if (SaveMatrixBattle._instance._matrix[x, y].objectInTile == ObjectInTile.PartOfShip) {
                    SaveMatrixBattle._instance._matrix[x, y].isSelectedThisTile = true;
                    SaveMatrixBattle._instance._matrix[x, y].ship._shipData._health--;
                    SaveMatrixBattle._instance._matrix[x, y].colorSelect = Color.green;
                    return true;
                }
                else if (SaveMatrixBattle._instance._matrix[x, y].objectInTile == ObjectInTile.Ship) {
                    SaveMatrixBattle._instance._matrix[x, y].isSelectedThisTile = true;
                    SaveMatrixBattle._instance._matrix[x, y].ship._shipData._health--;
                    SaveMatrixBattle._instance._matrix[x, y].colorSelect = Color.green;
                    return true;
                }
                else if (SaveMatrixBattle._instance._matrix[x, y].objectInTile == ObjectInTile.Water) {
                    SaveMatrixBattle._instance._matrix[x, y].isSelectedThisTile = true;
                    SaveMatrixBattle._instance._matrix[x, y].colorSelect = Color.blue;
                    return false;
                }
            }

            return true;
        }
        public static IEnumerator TurnEnemy()
        {
            yield return new WaitForSeconds(5);
            int x = Random.Range(0, 10);
            int y = Random.Range(0, 10);
            while (_isTurnEnemy) {
                if (AttackEnemy(x, y)) {
                    x = Random.Range(0, 10);
                    y = Random.Range(0, 10);
                    yield return new WaitForSeconds(1);
                }
                else {

                    _isTurnEnemy = false;
                }
            }
            _isTurnPlayer = true;
            yield return new WaitForSeconds(5f);
            yield return null;
        }
    }
}
