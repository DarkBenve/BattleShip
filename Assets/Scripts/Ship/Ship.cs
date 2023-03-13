using System;
using System.Drawing;
using UnityEngine;

namespace BattleShip
{
    struct ShipData
    {
        private int _sizeShip;
        private int _health;
        //Bool Direction che mi permetterà di capire la nave in che modo è girata

        public ShipData(int sizeShip)
        {
            _sizeShip = sizeShip;
            _health = sizeShip;
        }
    }
    public class Ship : MonoBehaviour
    {
        [Range(1, 3)][SerializeField] public int sizeShip;

        private ShipData _shipData;
        private Vector3 _transformLocalScale;
        private void Start()
        {
            _shipData = new ShipData(sizeShip);
        }
    }
}
