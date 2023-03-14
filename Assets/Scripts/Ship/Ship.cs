using System;
using System.Drawing;
using UnityEngine;

namespace BattleShip
{
    public struct ShipData
    {
        public int _sizeShip;
        public int _health;

        public ShipData(int sizeShip)
        {
            _sizeShip = sizeShip;
            _health = sizeShip;
        }
    }
    public class Ship : MonoBehaviour
    {
        [Range(1, 3)][SerializeField] public int sizeShip;
        public bool isDeath;
        public ShipData _shipData;
        private Vector3 _transformLocalScale;
        private void Start()
        {
            _shipData = new ShipData(sizeShip);
            isDeath = false;
        }

        private void Update()
        {
            if (_shipData._health <= 0) {
                isDeath = true;
            }

            if (isDeath) {
                gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
                Destroy(gameObject, 5f);
            }
        }
    }
}
