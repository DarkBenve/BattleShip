using System;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = System.Diagnostics.Debug;

namespace BattleShip
{
    public class ManagerChooseOrderShip : MonoBehaviour
    {
        public int widthMatrix;
        public int heightMatrix;
        public Ship shipSelected;
        public MatrixGenerate matrixPlayer;

        private Transform _containerPlayerTile;
        // public MatrixGenerate matrixEnemy;

        private Ray _mainRay;
        private const char Separetor = ',';


        private void Start()
        {
            matrixPlayer = new MatrixGenerate(widthMatrix, heightMatrix, true);
            ManagerSelectionShip._instance._onSelect = SelectShip;
            _containerPlayerTile = GameObject.FindGameObjectWithTag("Container").transform;
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
                                if (ManagerSelectionShip._instance.currentNSmallShip ==
                                    ManagerSelectionShip.NMaxSmallShip) {
                                    ManagerSelectionShip._instance.currentNSmallShip =
                                        ManagerSelectionShip.NMaxSmallShip;
                                    shipSelected = null;
                                }
                            }
                        }

                        if (shipSelected.sizeShip == 2) {
                            if (ManagerSelectionShip._instance.currentNMediumShip <
                                ManagerSelectionShip.NMaxMediumShip) {
                                if (PositionShipDoubleTile(positionInWorld, coordinated, shipSelected, hit))
                                    ManagerSelectionShip._instance.currentNMediumShip++;
                                if (ManagerSelectionShip._instance.currentNMediumShip ==
                                    ManagerSelectionShip.NMaxMediumShip) {
                                    ManagerSelectionShip._instance.currentNMediumShip =
                                        ManagerSelectionShip.NMaxMediumShip;
                                    shipSelected = null;
                                }
                            }
                        }

                        if (shipSelected.sizeShip == 3) {
                            if (ManagerSelectionShip._instance.currentNBigShip < ManagerSelectionShip.NMaxBigShip) {
                                if (PositionShipTripleTile(positionInWorld, coordinated, shipSelected, hit))
                                    ManagerSelectionShip._instance.currentNBigShip++;
                                if (ManagerSelectionShip._instance.currentNBigShip ==
                                    ManagerSelectionShip.NMaxBigShip) {
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
            var shipInTile = Instantiate(ship, positionInWorld, Quaternion.identity);
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship = shipInTile;
            matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship.shipType = TypeShip.PlayerShip;
            shipInTile.transform.SetParent(_containerPlayerTile);
        }

        private bool PositionShipDoubleTile(Vector3 positionWorld, Vector2 coordinatedLogic, Ship ship, RaycastHit hit)
        {
            int count = 0;

            if (ManagerSelectionShip._instance.isRotate) {
                for (int i = 0; i < 1; i++) {
                    if (coordinatedLogic.x + i < widthMatrix - 1) {
                        count++;
                    }
                }

                if (count == 1) {
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 1, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                    Ship instantiate = Instantiate(ship, positionWorld, Quaternion.identity);
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 1, (int)coordinatedLogic.y].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship.shipType = TypeShip.PlayerShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 1, (int)coordinatedLogic.y].ship.shipType = TypeShip.PlayerShip;
                    instantiate.transform.Rotate(new Vector3(0, 90, 0));
                    instantiate.transform.SetParent(_containerPlayerTile);
                    return true;
                }
                else {
                    Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                    tile.meshRenderer.material.color = Color.red;
                }
            }
            else {
                for (int i = 0; i < 1; i++) {
                    if (coordinatedLogic.y + i < heightMatrix - 1) {
                        count++;
                    }
                }

                if (count == 1) {
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].objectInTile = ObjectInTile.PartOfShip;
                    var instantiate = Instantiate(ship, positionWorld, Quaternion.identity);
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship.shipType = TypeShip.PlayerShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].ship.shipType = TypeShip.PlayerShip;
                    instantiate.transform.SetParent(_containerPlayerTile);
                    return true;
                }
                else {
                    Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                    tile.meshRenderer.material.color = Color.red;
                }
            }
            return default;
        }

        private bool PositionShipTripleTile(Vector3 positionWorld, Vector2 coordinatedLogic, Ship ship, RaycastHit hit)
        {
            int count = 0;


            if (ManagerSelectionShip._instance.isRotate) {
                for (int i = 0; i < 2; i++) {
                    if (coordinatedLogic.x + i < widthMatrix - 1) {
                        count++;
                    }
                }

                if (count == 2) {
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 1, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 2, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                    Ship instantiate = Instantiate(ship, positionWorld, Quaternion.identity);
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 1, (int)coordinatedLogic.y].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 2, (int)coordinatedLogic.y].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship.shipType = TypeShip.PlayerShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 1, (int)coordinatedLogic.y].ship.shipType = TypeShip.PlayerShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x + 2, (int)coordinatedLogic.y].ship.shipType = TypeShip.PlayerShip;
                    instantiate.transform.Rotate(new Vector3(0, 90, 0));
                    instantiate.transform.SetParent(_containerPlayerTile);
                    return true;
                }
                else {
                    Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                    tile.meshRenderer.material.color = Color.red;
                }
            }
            else {
                for (int i = 0; i < 2; i++) {
                    if (coordinatedLogic.y + i < heightMatrix - 1) {
                        count++;
                    }
                }

                if (count == 2) {
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].objectInTile = ObjectInTile.PartOfShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].objectInTile = ObjectInTile.PartOfShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 2].objectInTile = ObjectInTile.PartOfShip;
                    Ship instantiate = Instantiate(ship, positionWorld, Quaternion.identity);
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 2].ship = instantiate;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y].ship.shipType = TypeShip.PlayerShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 1].ship.shipType = TypeShip.PlayerShip;
                    matrixPlayer._matrixPlayer[(int)coordinatedLogic.x, (int)coordinatedLogic.y + 2].ship.shipType = TypeShip.PlayerShip;
                    instantiate.transform.SetParent(_containerPlayerTile);
                    return true;
                }
                else {
                    Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                    tile.meshRenderer.material.color = Color.red;
                }
            }

            return default;
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

