using System;
using UnityEngine;

namespace BattleShip
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int widhtMatrix;
        [SerializeField] private int heightMatrix;
        public MatrixGenerate matrixPlayer;
        public MatrixGenerate matrixEnemy;
        private void Start()
        {
            matrixPlayer = new MatrixGenerate(widhtMatrix, heightMatrix, true);
            matrixPlayer = gameObject.AddComponent<MatrixGenerate>();
            matrixEnemy = new MatrixGenerate(widhtMatrix, heightMatrix, false);
            matrixEnemy = gameObject.AddComponent<MatrixGenerate>();
        }
    }
}
