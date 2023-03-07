using System;
using UnityEngine;

namespace BattleShip
{
    struct ShipData
    {
        private int _sizeShip;

        public ShipData(int sizeShip)
        {
            _sizeShip = sizeShip;
        }
    }
    public class Ship : MonoBehaviour
    {
        [Range(1, 3)][SerializeField] private int sizeShip;

        private ShipData _shipData;
        private void Start()
        {
            _shipData = new ShipData(sizeShip);
        }
    }
}
