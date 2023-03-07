using System;
using UnityEngine;

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
        private void Awake()
        {
            _objectInTile = ObjectInTile.Water;
        }
    }
}
