using System;
using UnityEngine;

namespace BattleShip
{
    public class TileEnemy : Tile
    {
        private void OnMouseDown()
        {
            if (ManagerBattleSystem._isTurnPlayer) {
                if (!isSelectedThisTile) {
                    if (ship != null && objectInTile == ObjectInTile.Ship) {
                        ship._shipData._health--;
                        objectInTile = ObjectInTile.Water;
                        meshRenderer.material.color = Color.green;
                        colorSelect = Color.green;
                        isSelectedThisTile = true;
                        ManagerBattleSystem._isTurnPlayer = true;
                    }
                    if (ship != null && objectInTile == ObjectInTile.PartOfShip) {
                        ship._shipData._health--;
                        objectInTile = ObjectInTile.Water;
                        meshRenderer.material.color = Color.green;
                        colorSelect = Color.green;
                        isSelectedThisTile = true;
                        ManagerBattleSystem._isTurnPlayer = true;
                    }
                    if (ship == null && objectInTile == ObjectInTile.Water){
                        meshRenderer.material.color = Color.blue;
                        colorSelect = Color.blue;
                        isSelectedThisTile = true;
                        ManagerBattleSystem._isTurnPlayer = false;
                        ManagerBattleSystem._isTurnEnemy = true;
                    }
                }
            }
        }

        protected override void Init()
        {
            objectInTile = ObjectInTile.Water;
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.material.color = Color.cyan;
        }

        protected override void ChangeColor()
        {
            meshRenderer.material.color = Color.white;
        }
    }
}
