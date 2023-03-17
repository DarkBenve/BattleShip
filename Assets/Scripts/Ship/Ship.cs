using System;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

namespace BattleShip
{
    public enum TypeShip
    {
        PlayerShip,
        EnemyShip
    }
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
        public TypeShip shipType;
        public bool isDeath;
        public ShipData _shipData;
        private Vector3 _transformLocalScale;

        private int _k = 0;
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
                if (shipType == TypeShip.EnemyShip) {
                    DeathShipEnemy();
                }

                if (shipType == TypeShip.PlayerShip) {
                    DeathShipPlayer();
                }
            }
        }

        private void DeathShipEnemy()
        {
            if (_k == 0) {
                gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
                gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                GameManager._instance.nShipDeathEnemy++;
                // Destroy(gameObject, 2.5f);
                _k = 1;
            }
        }

        private void DeathShipPlayer()
        {
            if (_k == 0) {
                gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
                gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                GameManager._instance.nShipDeathPlayer++;
                // Destroy(gameObject, 2.5f);
                _k = 1;
            }
        }
    }
}
