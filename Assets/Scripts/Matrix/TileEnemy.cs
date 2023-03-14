using System;
using UnityEngine;

namespace BattleShip
{
    public class TileEnemy : Tile
    {
        private void OnMouseDown()
        {
            if (ship != null && objectInTile == ObjectInTile.PartOfShip) {
                ship._shipData._health--;
                objectInTile = ObjectInTile.Water;
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
