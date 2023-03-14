using System;
using UnityEngine;

namespace BattleShip
{
    public class SaveMatrixBattle : MonoBehaviour
    {
        public Tile[,] _matrix;
        private static ManagerChooseOrderShip _managerOrderShip;

        private void Start()
        {
            _managerOrderShip = FindObjectOfType<ManagerChooseOrderShip>();
            _matrix = new Tile[_managerOrderShip.widthMatrix, _managerOrderShip.heightMatrix];
        }

        private void Update()
        {
            if (ManagerSelectionShip._instance.isReadyGoBattle) {
                SaveMatrix();
            }
        }

        private void SaveMatrix()
        {
            for (int i = 0; i < _managerOrderShip.heightMatrix; i++) {
                for (int j = 0; j < _managerOrderShip.widthMatrix; j++) {
                    _matrix[i, j] = _managerOrderShip.matrixPlayer._matrixPlayer[i, j];
                }
            }
        }
    }
}
