using System.Collections;
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
                    SaveMatrixBattle._instance._matrix[x, y].colorSelect = Color.cyan;
                    return false;
                }
            }

            return true;
        }
        public static IEnumerator TurnEnemy()
        {
            yield return new WaitForSeconds(5);
            //Attack Enemy
            int x = Random.Range(0, 10);
            int y = Random.Range(0, 10);
            while (_isTurnEnemy) {
                if (AttackEnemy(x, y)) {
                    // yield return new WaitForSeconds(2);
                    yield return new WaitForSeconds(2);
                }
                else {

                    _isTurnEnemy = false;
                    yield return new WaitForSeconds(3f);
                }
            }
            _isTurnPlayer = true;
            yield return null;
        }
    }
}
