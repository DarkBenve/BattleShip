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

        public Ship shipSelected;

        private void Start()
        {
            matrixPlayer = new MatrixGenerate(widthMatrix, heightMatrix, true);
            ManagerSelectionShip._instance._onSelect = SelectShip;
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
            if (shipSelected != null) {
                if (Input.GetKeyDown(ControllerMapping._clickSelection))
                if (Physics.Raycast(_mainRay, out hit)) {
                    string nameObjectHit = hit.collider.gameObject.name;
                    Vector3 positionInWorld = hit.collider.gameObject.transform.position;
                    Vector2 coordinated = GetCoordinate(nameObjectHit);
                    if (shipSelected.sizeShip == 1) {
                        if (ManagerSelectionShip._instance.currentNSmallShip < ManagerSelectionShip.NMaxSmallShip) {
                            ManagerSelectionShip._instance.currentNSmallShip++;
                            PositionShipSingleTile(positionInWorld, coordinated, shipSelected);
                            if (ManagerSelectionShip._instance.currentNSmallShip == ManagerSelectionShip.NMaxSmallShip){
                                ManagerSelectionShip._instance.currentNSmallShip = ManagerSelectionShip.NMaxSmallShip;
                                shipSelected = null;
                            }
                        }
                    }

                    if (shipSelected.sizeShip == 2) {
                        if (ManagerSelectionShip._instance.currentNMediumShip < ManagerSelectionShip.NMaxMediumShip) {
                            if (PositionShipDoubleTile(positionInWorld, coordinated, shipSelected))
                                ManagerSelectionShip._instance.currentNMediumShip++;
                            if (ManagerSelectionShip._instance.currentNMediumShip == ManagerSelectionShip.NMaxMediumShip){
                                ManagerSelectionShip._instance.currentNMediumShip = ManagerSelectionShip.NMaxMediumShip;
                                shipSelected = null;
                            }
                        }
                    }

                    if (shipSelected.sizeShip == 3) {
                        if (ManagerSelectionShip._instance.currentNBigShip < ManagerSelectionShip.NMaxBigShip) {
                            if (PositionShipTripleTile(positionInWorld, coordinated, shipSelected))
                                ManagerSelectionShip._instance.currentNBigShip++;
                            if (ManagerSelectionShip._instance.currentNBigShip == ManagerSelectionShip.NMaxBigShip){
                                ManagerSelectionShip._instance.currentNBigShip = ManagerSelectionShip.NMaxBigShip;
                                shipSelected = null;
                            }
                        }
                    }
                }
            }
        }

        private Ship SelectShip(Ship ship)
        {
            shipSelected = ship;
            return ship;
        }

        private void PositionShipSingleTile(Vector3 positionInWorld, Vector2 coordinatedLogic, Ship ship)
        {
            //prima di posizionare la nave si sceglie la direzione che deve avere
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.Ship;
            Instantiate(ship, positionInWorld, Quaternion.identity);
        }

        private bool PositionShipDoubleTile(Vector3 positionWorld, Vector2 coordinatedLogic, Ship ship)
        {
            int count = 0;
            for (int i = 0; i < 1; i++) {
                if (coordinatedLogic.y + i < heightMatrix - 1) {
                    count++;
                }
            }

            if (count == 1) {
                matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].objectInTile = ObjectInTile.PartOfShip;
                Instantiate(ship, positionWorld, Quaternion.identity);
                return true;
            }
            else
                return false;
        }

        private bool PositionShipTripleTile(Vector3 positionWorld, Vector2 coordinatedLogic, Ship ship)
        {
            int count = 0;
            for (int i = 0; i < 2; i++) {
                if (coordinatedLogic.y + i < heightMatrix - 1) {
                    count++;
                }
            }

            if (count == 2) {
                matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].objectInTile = ObjectInTile.PartOfShip;
                matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 2].objectInTile = ObjectInTile.PartOfShip;
                Instantiate(ship, positionWorld, Quaternion.identity);
                return true;
            }
            else
                return false;
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
