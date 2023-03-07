using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleShip
{
    public enum ObjectInTile
    {
        Water,
        PartOfShip,
        Ship
    }
    public class Tile: MonoBehaviour
    {
        private ObjectInTile _objectInTile;
        public SpriteRenderer spriteRenderer;
        private void Awake()
        {
            _objectInTile = ObjectInTile.Water;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void OnMouseEnter()
        {
            spriteRenderer.color = Color.red;
        }

        private void OnMouseExit()
        {
            spriteRenderer.color = Color.white;
        }
    }
}
