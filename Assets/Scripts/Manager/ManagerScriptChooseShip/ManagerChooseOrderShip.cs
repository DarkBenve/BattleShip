using System;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = System.Diagnostics.Debug;

namespace BattleShip
{
    public class ManagerChooseOrderShip : MonoBehaviour
    {
        [SerializeField] private int widthMatrix;
        [SerializeField] private int heightMatrix;
        public MatrixGenerate matrixPlayer;
        // public MatrixGenerate matrixEnemy;

        private Ray _mainRay;
        private const char Separetor = ',';

        private bool _isSelected;
        private Ship _shipSelected;
        // private Ship obj;

        private void Start()
        {
            matrixPlayer = new MatrixGenerate(widthMatrix, heightMatrix, true);
            ManagerSelectionShip._instance._onSelect = SelectShip;
            // matrixEnemy = new MatrixGenerate(widhtMatrix, heightMatrix, false);
        }


        private void Update()
        {
            CheckRaycast();
            // if (_isSelected) {
            //     obj = Instantiate(_shipSelected);
            //     _isSelected = false;
            // }
            //
            // if (obj != null) {
            //     obj.transform.Translate(Input.mousePosition);
            // }
        }

        private void CheckRaycast()
        {
            _mainRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetKeyDown(ControllerMapping._clickSelection))
                if (Physics.Raycast(_mainRay, out hit)) {
                    string nameObjectHit = hit.collider.gameObject.name;
                    Vector3 positionInWorld = hit.collider.gameObject.transform.position;
                    Vector2 coordinated = GetCoordinate(nameObjectHit);
                    if (_shipSelected.sizeShip == 1) {
                        PositionShipSingleTile(positionInWorld, coordinated, _shipSelected);
                    }

                    if (_shipSelected.sizeShip == 2) {
                        PositionShipDoubleTile(positionInWorld, coordinated, _shipSelected);
                    }

                    if (_shipSelected.sizeShip == 3) {
                        PositionShipTripleTile(positionInWorld, coordinated, _shipSelected);
                    }
                }
        }

        private Ship SelectShip(Ship ship)
        {
            _isSelected = true;
            _shipSelected = ship;
            return ship;
        }

        private void PositionShipSingleTile(Vector3 positionInWorld, Vector2 coordinatedLogic, Ship ship)
        {
            //prima di posizionare la nave si sceglie la direzione che deve avere
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.Ship;
            Instantiate(ship, positionInWorld, Quaternion.identity);
        }

        private void PositionShipDoubleTile(Vector3 positionWorld, Vector2 coordinatedLogic, Ship ship)
        {
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].objectInTile = ObjectInTile.PartOfShip;
            Instantiate(ship, positionWorld, Quaternion.identity);
        }

        private void PositionShipTripleTile(Vector3 positionWorld, Vector2 coordinatedLogic, Ship ship)
        {
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].objectInTile = ObjectInTile.PartOfShip;
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 2].objectInTile = ObjectInTile.PartOfShip;
            Instantiate(ship, positionWorld, Quaternion.identity);
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
