using System;
using System.Drawing;
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
        private Vector3 _transformLocalScale;
        private void Start()
        {
            _shipData = new ShipData(sizeShip);
        }

        private void Update()
        {
            ShipCreate();
        }

        private void ShipCreate()
        {
            switch (sizeShip) {
                case 1:
                    Debug.Log("Grandezza 1-Tile");
                    break;
                case 2:
                    Debug.Log("Grandezza 2-Tile");
                    break;
                case 3:
                    Debug.Log("Grandezza 3-Tile");
                    break;
            }
        }
    }
}
