using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleShip
{
    public class ManagerSelectionShip : MonoBehaviour
    {
        public static ManagerSelectionShip _instance;
        public Func<Ship, Ship> _onSelect;
        public List<Ship> shipList;

        private void Start()
        {
            if (_instance == null) {
                _instance = this;
            }
            else {
                Destroy(this);
            }
        }

        public void SelectShip(int sizeShipIndex)
        {
            foreach (Ship ship in shipList) {
                if (ship.sizeShip == sizeShipIndex) {
                    _onSelect.Invoke(ship);
                }
            }
        }
    }
}
