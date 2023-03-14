using System;
using UnityEngine;

namespace BattleShip
{
    public class TileEnemy : Tile
    {
        private Color _colorSelect;
        private void OnMouseDown()
        {
            if (!_isSelectedThisTile) {
                if (ship != null && objectInTile == ObjectInTile.Ship) {
                    ship._shipData._health--;
                    objectInTile = ObjectInTile.Water;
                    spriteRenderer.color = Color.green;
                    _colorSelect = Color.green;
                    _isSelectedThisTile = true;
                }
                else {
                    spriteRenderer.color = Color.cyan;
                    _colorSelect = Color.cyan;
                    _isSelectedThisTile = true;
                }
                if (ship != null && objectInTile == ObjectInTile.PartOfShip) {
                    ship._shipData._health--;
                    objectInTile = ObjectInTile.Water;
                    spriteRenderer.color = Color.green;
                    _colorSelect = Color.green;
                    _isSelectedThisTile = true;
                }
                else {
                    spriteRenderer.color = Color.cyan;
                    _colorSelect = Color.cyan;
                    _isSelectedThisTile = true;
                }
            }
        }

        private void Update()
        {
            if (_isSelectedThisTile) {
                spriteRenderer.color = _colorSelect;
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
