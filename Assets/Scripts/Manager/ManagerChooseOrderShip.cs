using System;
using UnityEngine;

namespace BattleShip
{
    public class ManagerChooseOrderShip : MonoBehaviour
    {
        [SerializeField] private int widhtMatrix;
        [SerializeField] private int heightMatrix;
        public MatrixGenerate matrixPlayer;
        public MatrixGenerate matrixEnemy;

        private Ray _mainRay;
        private const char Separetor = ',';

        private void Start()
        {
            matrixPlayer = new MatrixGenerate(widhtMatrix, heightMatrix, true);
            matrixPlayer = gameObject.AddComponent<MatrixGenerate>();
            // matrixEnemy = new MatrixGenerate(widhtMatrix, heightMatrix, false);
            // matrixEnemy = gameObject.AddComponent<MatrixGenerate>();
        }

        private void Update()
        {
            CheckRaycast();
        }

        private void CheckRaycast()
        {
            _mainRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(_mainRay, out hit)) {
                string nameObjectHit = hit.collider.gameObject.name;
                Vector2 coordinate = GetCoordinate(nameObjectHit);
                Debug.Log(coordinate.x);
                Debug.Log(coordinate.y);
            }
        }

        private Vector2 GetCoordinate(string nameObject)
        {
            string[] array = nameObject.Split(Separetor);
            int x = int.Parse(array[0]);
            int y = int.Parse(array[1]);
            return new Vector2(x, y);
        }
    }
}
