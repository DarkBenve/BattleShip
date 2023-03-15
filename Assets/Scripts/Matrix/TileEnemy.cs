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
                        spriteRenderer.color = Color.green;
                        colorSelect = Color.green;
                        isSelectedThisTile = true;
                        ManagerBattleSystem._isTurnPlayer = true;
                    }
                    if (ship != null && objectInTile == ObjectInTile.PartOfShip) {
                        ship._shipData._health--;
                        objectInTile = ObjectInTile.Water;
                        spriteRenderer.color = Color.green;
                        colorSelect = Color.green;
                        isSelectedThisTile = true;
                        ManagerBattleSystem._isTurnPlayer = true;
                    }
                    if (ship == null && objectInTile == ObjectInTile.Water){
                        spriteRenderer.color = Color.cyan;
                        colorSelect = Color.cyan;
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
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        protected override void ChangeColor()
        {
            spriteRenderer.color = Color.blue;
        }
    }
}
