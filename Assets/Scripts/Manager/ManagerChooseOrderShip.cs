using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleShip
{
    public class ManagerChooseOrderShip : MonoBehaviour
    {
        [SerializeField] private int widhtMatrix;
        [SerializeField] private int heightMatrix;
        public MatrixGenerate matrixPlayer;
        // public MatrixGenerate matrixEnemy;

        private Ray _mainRay;
        private const char Separetor = ',';

        [SerializeField] private Ship debugShipProva;  //da togliere dopo

        private void Start()
        {
            matrixPlayer = new MatrixGenerate(widhtMatrix, heightMatrix, true);
            // matrixEnemy = new MatrixGenerate(widhtMatrix, heightMatrix, false);
        }

        private void Update()
        {
            CheckRaycast();
        }

        private void CheckRaycast()
        {
            _mainRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetKeyDown(ControllerMapping._clickSelection))
                if (Physics.Raycast(_mainRay, out hit)) {
                    string nameObjectHit = hit.collider.gameObject.name;
                    Vector3 positionInWorld = hit.collider.gameObject.transform.position;
                    Vector2 coordinatelogic = GetCoordinate(nameObjectHit);
                    PositionShipSingleTile(positionInWorld, coordinatelogic, debugShipProva);
                }
        }

        private void PositionShipSingleTile(Vector3 positionInWorld, Vector2 coordinatelogic, Ship ship)
        {
            //prima di posizionare la nave si sceglie la direzione che deve avere
            matrixPlayer._matrixPlayer[(int)coordinatelogic.x, (int)coordinatelogic.y].objectInTile = ObjectInTile.Ship;
            Instantiate(ship, positionInWorld, Quaternion.identity);
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
